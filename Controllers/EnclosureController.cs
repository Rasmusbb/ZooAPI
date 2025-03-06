using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Data;
using ZooAPI.DTOs;
using ZooAPI.Interfaces;
using ZooAPI.models;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnclosureController : Controller
    {
        private readonly ZooAPIContext _context;
        private readonly IConfiguration _configuration;

        private readonly string DsetNull = "Entity set 'DatabaseContext.Enclosure' is null.";
        public EnclosureController(ZooAPIContext context, IConfiguration iConfig)
        {
            _context = context;
            _configuration = iConfig;
        }

        [HttpPost("AddEnclosure")]
        public async Task<ActionResult<EnclosureDTO>> EnclosureUser(EnclosureDTO EnclosureDTO)
        {
            if (_context.enclosures == null)
            {
                return Problem(DsetNull);
            }
            Enclosure enclosure = EnclosureDTO.Adapt<Enclosure>();
            enclosure.Statues = EnclosureStatues.Empty;
            _context.enclosures.Add(enclosure);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEnclosure", new { id = enclosure.EnclosureID }, enclosure);

        }

        [HttpGet("Enclosure")]
        public async Task<ActionResult<EnclosureDTO>> GetEnclosure(Guid EnclosureID)
        {
            if (_context.enclosures == null)
            {
                return Problem(DsetNull);
            }
            Enclosure Enclosure = await _context.enclosures.FindAsync(EnclosureID);
            if (User == null)
            {
                return NotFound();
            }
            return Enclosure.Adapt<EnclosureDTO>();
        }


        //[Authorize]
        [HttpGet("GetAllEnclosure")]
        public async Task<ActionResult<List<EnclosureDTOID>>> GetAllEnclosure()
        {
            List<Enclosure> enclosures = _context.enclosures.ToList();
            return enclosures.Adapt<List<EnclosureDTOID>>();

        }

        [HttpPost("AddStaff")]
        public async Task<ActionResult> AddStaffToEncloure(Guid EncloureID,Guid UserID)
        {

            if (_context.enclosures == null && _context.Users == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(UserID);
            Enclosure enclosure = await _context.enclosures.FindAsync(EncloureID);
            if (enclosure.Users.Contains(user))
            {
                return BadRequest("User already added to enclosure");
            }
            enclosure.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPost("AddAnimal")]
        public async Task<ActionResult> AddAnimal(Guid EncloureID, Guid AnimalID)
        {
            if (_context.enclosures == null && _context.Animals == null)
            {
                return Problem(DsetNull);
            }
            User user = await _context.Users.FindAsync(AnimalID);
            Enclosure enclosure = await _context.enclosures.FindAsync(EncloureID);
            enclosure.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }


    }


}
