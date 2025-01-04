using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Data;
using SuperheroApi.Models;


namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly ApiDbContext _context;

        // Constructor that accepts the database context
        public SuperheroController(ApiDbContext context)
        {
            _context = context;
        }

        // Endpoint to search for superheroes by name
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchSuperhero(string name)
        {
            // Fetch all superheroes from the database
            var superheroes = await _context.Superheroes.ToListAsync();

            // Perform case-insensitive search in memory
            var result = superheroes
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(result);
        }

        // Endpoint to add a favorite superhero
        [HttpPost("favorites")]
        public async Task<IActionResult> AddFavorite([FromBody] string superheroName)
        {
            // Fetch all superheroes from the database
            var superheroes = await _context.Superheroes.ToListAsync();

            // Perform case-insensitive search in memory
            var superhero = superheroes
                .FirstOrDefault(s => s.Name.Equals(superheroName, StringComparison.OrdinalIgnoreCase));

            if (superhero != null && !await _context.FavoriteSuperheroes.AnyAsync(f => f.SuperheroId == superhero.Id))
            {
                var favoriteSuperhero = new FavoriteSuperhero
                {
                    SuperheroId = superhero.Id,
                    Superhero = superhero
                };

                _context.FavoriteSuperheroes.Add(favoriteSuperhero);
                await _context.SaveChangesAsync();
                return Created("", favoriteSuperhero);
            }
            return BadRequest("Superhero not found or already in favorites.");
        }

        // Endpoint to get the list of favorite superheroes
        [HttpGet("favorites")]
        public async Task<IActionResult> GetFavorites()
        {
            var favorites = await _context.FavoriteSuperheroes
                .Include(f => f.Superhero)
                .ToListAsync();
            return Ok(favorites);
        }
    }
}
