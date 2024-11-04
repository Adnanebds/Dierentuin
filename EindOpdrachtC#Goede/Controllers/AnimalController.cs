using Microsoft.AspNetCore.Mvc;
using Dierentuin.Models;
using Microsoft.EntityFrameworkCore;
using EindOpdrachtC_Goede.Models.Enums;

namespace Dierentuin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly ZooContext _context;

        public AnimalController(ZooContext context)
        {
            _context = context;
        }

        // a. CRUD operations on animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await _context.Animals.Include(a => a.Category).Include(a => a.Enclosure).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return animal;
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal([FromBody] Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Console.WriteLine($"Received animal: Name={animal.Name}, Species={animal.Species}, Size={animal.Size}");

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Saved animal with ID: {animal.Id}");

            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // b. Searching/filtering on all properties
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Animal>>> SearchAnimals(string name = null, string species = null)
        {
            var query = _context.Animals.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(species))
            {
                query = query.Where(a => a.Species.Contains(species));
            }

            return await query.Include(a => a.Category).Include(a => a.Enclosure).ToListAsync();
        }

        // c. Action Sunrise
        [HttpGet("{id}/sunrise")]
        public ActionResult<string> Sunrise(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
            { 
                return NotFound();
            }
            // Example logic for Sunrise
            switch (animal.ActivityPattern)
            {
                case ActivityPattern.Diurnal:
                    return "The animal wakes up.";
                case ActivityPattern.Nocturnal:
                    return "The animal goes to sleep.";
                default:
                    return "Activity pattern not defined.";
            }
        }

        // d. Action Sunset
        [HttpGet("{id}/sunset")]
        public ActionResult<string> Sunset(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            // Example logic for Sunset
            switch (animal.ActivityPattern)
            {
                case ActivityPattern.Diurnal:
                    return "The animal goes to sleep.";
                case ActivityPattern.Nocturnal:
                    return "The animal wakes up.";
                default:
                    return "Activity pattern not defined.";
            }
        }

        // e. Action Feeding Time
        [HttpGet("{id}/feedingtime")]
        public ActionResult<string> FeedingTime(int id)
        {
            var animal = _context.Animals.Include(a => a.Prey).FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            // Logic to determine feeding time
            if (animal.Prey != null && animal.Prey.Any())
            {
                return $"{animal.Name} preys on {string.Join(", ", animal.Prey.Select(p => p.Name))}.";
            }
            return $"{animal.Name} eats {animal.Diet}.";
        }

        // f. Action Check Constraints
        [HttpGet("{id}/checkconstraints")]
        public ActionResult<string> CheckConstraints(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            // Logic to check constraints (example)
            var constraints = new List<string>();
            if (animal.SpaceRequirement <= 0)
            {
                constraints.Add("Space requirement not met.");
            }
            // Add more checks based on your criteria
            return Ok(constraints);
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
