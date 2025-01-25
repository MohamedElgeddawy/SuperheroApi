using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Models;



namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly ApiDbContext _context;
        // Constructor that accepts the database context
        public SuperheroController(IUnitOfWork unitOfWork, ApiDbContext context)
        {
            _unitOfwork = unitOfWork;
            _context = context;

        }

        [Authorize]
        // Endpoint to get all information of a character by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperheroById(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Powerstats)
                .Include(s => s.Biography)
                .Include(s => s.Appearance)
                .Include(s => s.Work)
                .Include(s => s.Connections)
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null)
            {
                return NotFound("Superhero not found.");
            }

            return Ok(superhero);
        }

        // Endpoint to get powerstats of a character by ID
        [HttpGet("{id}/powerstats")]
        public async Task<IActionResult> GetPowerstats(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Powerstats)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Powerstats == null)
            {
                return NotFound("Powerstats not found.");
            }

            return Ok(superhero.Powerstats);
        }

        // Endpoint to get biography of a character by ID
        [HttpGet("{id}/biography")]
        public async Task<IActionResult> GetBiography(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Biography)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Biography == null)
            {
                return NotFound("Biography not found.");
            }

            return Ok(superhero.Biography);
        }

        // Endpoint to get appearance of a character by ID
        [HttpGet("{id}/appearance")]
        public async Task<IActionResult> GetAppearance(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Appearance)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Appearance == null)
            {
                return NotFound("Appearance not found.");
            }

            return Ok(superhero.Appearance);
        }

        // Endpoint to get work details of a character by ID
        [HttpGet("{id}/work")]
        public async Task<IActionResult> GetWork(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Work)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Work == null)
            {
                return NotFound("Work details not found.");
            }

            return Ok(superhero.Work);
        }

        // Endpoint to get connections of a character by ID
        [HttpGet("{id}/connections")]
        public async Task<IActionResult> GetConnections(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Connections)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Connections == null)
            {
                return NotFound("Connections not found.");
            }

            return Ok(superhero.Connections);
        }

        // Endpoint to get image URL of a character by ID
        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetImage(int id)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null || superhero.Image == null)
            {
                return NotFound("Image not found.");
            }

            return Ok(superhero.Image);
        }

       
    }
}
