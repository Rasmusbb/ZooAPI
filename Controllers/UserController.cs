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

        public UserController(ZooAPIContext context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        public async Task<ActionResult<UserDTOID>> Login(string Email, string Password)
        {
            User User = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User.Adapt<UserDTOID>());
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserDTO>> AddUser(CreateUserDTO UserDTO)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DatabaseContext.User'  is null.");
            }
            User User = UserDTO.Adapt<User>();
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = User.UserID },User);

        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid UserID)
        {
            var User = await _context.Users.FindAsync(UserID);
            if (User == null)
            {
                return NotFound();
            }
            return User.Adapt<UserDTO>();
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTOID>>> GetAllUsers()
        {
            List<User> users = _context.Users.ToList();
            return users.Adapt<List<UserDTOID>>();
        }

    }
}
