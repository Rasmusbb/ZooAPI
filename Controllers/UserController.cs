using Microsoft.AspNetCore.Mvc;
using ZooAPI.models;
using ZooAPI.Data;
using ZooAPI.DTOs;
using Mapster;
using System.Security.Cryptography;
using ZooAPI;
using NuGet.DependencyResolver;
using System.Data.Entity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;



namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly  ZooAPIContext _context;
        private readonly IConfiguration _configuration;

        private readonly string DsetNull = "Entity set 'DatabaseContext.User'  is null.";

        public UserController(ZooAPIContext context,IConfiguration iConfig)
        {
            _context = context;
            _configuration = iConfig;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<string>> Login(string Email, string Password)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            Email = Email.ToLower();
            User user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if(user != null)
            {
                string Hash2 = Hash(Password + user.UserID);
                if (Hash(Password + user.UserID) == user.Password)
                {
                
                    return GenerateJwtToken(user);
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser(CreateUserDTO userDTO)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
           
            userDTO.Email = userDTO.Email.ToLower();
            User user = userDTO.Adapt<User>();
            _context.Users.Add(user);
            user.Password = Hash(user.Password + user.UserID);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserID },user);

        }
        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid UserID)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User User = await _context.Users.FindAsync(UserID);
            if (User == null)
            {
                return NotFound();
            }
            return User.Adapt<UserDTO>();
        }
        [Authorize]
        [HttpPut("MakeUserDefault")]
        public async Task<ActionResult<UserDTO>> MakeUserZooKeeper(Guid UserID)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(UserID);
            user.Role = UserRole.User;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTOID>>> GetAllUsers(UserRole role)
        {
            List<User> users = _context.Users.ToList();
            return users.Adapt<List<UserDTOID>>();
        }
        [Authorize]
        [HttpPut("EditedUser")]

        public async Task<ActionResult<UserDTOID>> EditedUser(Guid UserID,UserDTO UserDTO)
        {

            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(UserID);
            user = UserDTO.Adapt<User>();
            
            _context.SaveChanges();

            if (user == null)
            {
                return NotFound(user.UserID);
            }
            
            return user.Adapt<UserDTOID>();
        }


        [Authorize]
        [HttpPut("ChangeUserPassword")]

        public async Task<ActionResult> ChangePassword(UserDTOPasID UserDTO)
        {

            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(UserDTO.UserID);
            user.Password = Hash(user.Password + user.UserID);
            user.changedDefault = true;
            _context.SaveChanges();

            if (user == null)
            {
                return NotFound(user.UserID);
            }

            return Ok("User Password Changed");
        }
        public static string Hash(string password)
        {

            StringBuilder builder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
            }
            return builder.ToString();
        }
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new Claim[]
            {
                new Claim("UserID", user.UserID.ToString()),
                new Claim("Role", user.Role.ToString()),
                new Claim("MainArea",user.mainArea),
                new Claim("Phone",user.Phone),
                new Claim("Email",user.Email),
                new Claim("ChangeDefault", user.changedDefault.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: "ZooAPI",
                audience: "ZooFrontEnd",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
