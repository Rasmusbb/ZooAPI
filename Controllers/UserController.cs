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
                string hash = Hash(Password + user.UserID);
                if (hash == user.Password)
                {
                
                    return GenerateJwtToken(user);
                }
                else
                {
                    return NotFound(hash);
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
            try
            {
                userDTO.Email = userDTO.Email.ToLower();
                User user = userDTO.Adapt<User>();
                _context.Users.Add(user);
                user.Password = Hash(userDTO.Password + user.UserID);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = user.UserID }, user);
            }
            catch
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<List<UserDTOID>>> GetAllUsers()
        {
            List<User> users = _context.Users.ToList();
            return users.Adapt<List<UserDTOID>>();
        }

        [Authorize]
        [HttpGet("GetUserEnclosures")]
        public async Task<ActionResult<List<EnclosureDTOID>>> GetUserEnclosures(Guid UserID,bool oppsitse = false)
        {
            List<Enclosure> Enclosures;
            if (!oppsitse)
            {
                Enclosures = _context.Users.Where(u => u.UserID == UserID).SelectMany(u => u.Enclosures).ToList();
            }
            else
            {
                Enclosures = _context.Users.Where(u => u.UserID == UserID).SelectMany(u => u.Enclosures).ToList();
            }

            return Enclosures.Adapt<List<EnclosureDTOID>>();
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
            user.Password = Hash(UserDTO.Password + user.UserID);
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
                new Claim("userID", user.UserID.ToString()),
                new Claim("name", user.Name.ToString() ?? "None"),
                new Claim("role", user.Role.ToString()),
                new Claim("mainArea",user.mainArea ?? "None"),
                new Claim("phone",user.Phone ?? "None"),
                new Claim("email",user.Email ?? "None"),
                new Claim("changeDefault", user.changedDefault.ToString())
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
