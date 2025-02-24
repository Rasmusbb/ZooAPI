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
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("AddEnclosure")]
        public async Task<ActionResult<UserDTO>> AddEnclosure(Guid UserID,Guid EncclosureID)
        {
            if (_context.Users == null)
            {
                return Problem(DsetNull);
            }
            if(_context.enclosures == null)
            {
                return Problem("enclosures is Null");
            }

            User user = await _context.Users.FindAsync(UserID);
            if (user.Role == UserRole.ZooKeeper)
            {
                
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
