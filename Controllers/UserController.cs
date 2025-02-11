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
using System.Security.Policy;
using Microsoft.AspNetCore.Identity;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly  ZooAPIContext _context;
        private readonly string DsetNull = "Entity set 'DatabaseContext.User'  is null.";

        public UserController(ZooAPIContext context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        public async Task<ActionResult<UserDTOID>> Login(string Email, string Password)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (Hash(Password + user.UserID) == user.Password)
            {
                return Ok(user.Adapt<UserDTOID>());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser(CreateUserDTO UserDTO)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = UserDTO.Adapt<User>();
            _context.Users.Add(user);
            user.Password = Hash(user.Password + user.UserID);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserID },user);

        }

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


       [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTOID>>> GetAllUsers(UserRole role)
        {
            List<User> users = _context.Users.ToList();
            return users.Adapt<List<UserDTOID>>();
        }

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
    }
}
