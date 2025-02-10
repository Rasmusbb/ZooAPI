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
    public class ZooKeeperController : ControllerBase
    {
        private readonly ZooAPIContext _context;
        private readonly string DsetNull = "Entity set 'DatabaseContext.User'  is null.";

        public ZooKeeperController(ZooAPIContext context)
        {
            _context = context;
        }

        [HttpPut("MakeUserZooKeeper")]
        public async Task<ActionResult<UserDTO>> MakeUserZooKeeper(Guid UserID)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(UserID);
            user.Role = UserRole.ZooKeeper;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("GetZooKeeper")]
        public async Task<ActionResult<ZooKeeper>> GetZooKeeper(Guid UserID)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            if (User == null)
            {
                return NotFound();
            }
            return await _context.ZooKeepers.FindAsync(UserID);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTOID>>> GetAllUsers(UserRole role)
        {
            List<User> users = await _context.Users.Where(u => u.Role == role).ToListAsync();
            return users.Adapt<List<UserDTOID>>();
        }

        [HttpPut("EditedUser")]

        public async Task<ActionResult<UserDTOID>> EditedUser(Guid UserID, UserDTO UserDTO)
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
