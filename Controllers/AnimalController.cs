using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooAPI.Data;
using ZooAPI.DTOs;
using ZooAPI.models;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AnimalController : Controller
    {

        private readonly ZooAPIContext _context;
        private readonly IConfiguration _configuration;

        private readonly string DsetNull = "Entity set 'DatabaseContext.Animal' is null.";
        public AnimalController(ZooAPIContext context, IConfiguration iConfig)
        {
            _context = context;
            _configuration = iConfig;
        }

        [HttpPost("AddAnimal")]
        public async Task<ActionResult<AnimalDTO>> AddAnimal(AnimalDTO AnimalDTO)
        {
            if (_context.Animals == null)
            {
                return Problem(DsetNull);
            }
            Animal animal = AnimalDTO.Adapt<Animal>();
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAnimal", new { id = animal.AnimalID }, animal);
        }




        [HttpGet("GetAnimal")]
        public async Task<ActionResult<AnimalDTOID>> GetAnimal(Guid AnimalID)
        {
            if (_context.Animals == null)
            {
                return Problem(DsetNull);
            }
            Animal Animal = await _context.Animals.FindAsync(AnimalID);
            if (Animal == null)
            {
                return NotFound();
            }
            return Animal.Adapt<AnimalDTOID>();
        }


        [HttpGet("GetAllAnimals")]
        public async Task<ActionResult<List<AnimalDTOID>>> GetAllUsers(string specie)
        {
            if (_context.Animals == null)
            {
                return Problem(DsetNull);
            }
            List<Animal> animals = _context.Animals.ToList();
            return animals.Adapt<List<AnimalDTOID>>();
        }

        [HttpGet("GetAllSpecies")]
        public async Task<ActionResult<List<SpeciesDTOID>>> GetAllSpecies(string specie)
        {
            if (_context.Species == null)
            {
                return Problem(DsetNull);
            }
            List<Specie> species = _context.Species.ToList();
            return specie.Adapt<List<SpeciesDTOID>>();
        }

        [HttpPut("EditAnimal")]
        public async Task<ActionResult<AnimalDTO>> EditAnimal(Guid AnimalID, AnimalDTO animalDTO)
        {
            if (_context.Animals == null)
            {
                return Problem(DsetNull);
            }
            Animal Animal = await _context.Animals.FindAsync(AnimalID);
            if(Animal == null)
            {
                return NotFound("Animal not found");
            }
            Animal = animalDTO.Adapt<Animal>();
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
