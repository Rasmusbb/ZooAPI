using Microsoft.AspNetCore.Mvc;
using ZooAPI.models;
using ZooAPI.Data;
using ZooAPI.DTOs;
using Mapster;
using ZooAPI;
using NuGet.DependencyResolver;
using System.Data.Entity;

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
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Adapt<UserDTOID>());
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
            List<User> users = await _context.Users.Where(u => u.Role == role).ToListAsync();
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
    }
}
