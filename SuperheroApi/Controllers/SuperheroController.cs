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

        // Endpoint to search for superheroes by name
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchSuperhero(string name)
        {
            var result = await _unitOfwork.Superheroes.GetByName(name);
            return Ok(result);
        }

        // Endpoint to add a favorite superhero
        [HttpPost("favorites")]
        public async Task<IActionResult> AddFavorite([FromBody] string superheroName)
        {
            var superheroes = await _context.Superheroes.ToListAsync();
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

        // Endpoint to Delete superheroe by name of favoritesuperheroes
        [HttpDelete("favorites/{name}")]
        public async Task<IActionResult> DeleteFavorite(string name)
        {
            var superheroes = await _context.Superheroes.ToListAsync();
            var superhero = superheroes
                .FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (superhero != null)
            {
                var favorite = await _context.FavoriteSuperheroes
                    .FirstOrDefaultAsync(f => f.SuperheroId == superhero.Id);
                if (favorite != null)
                {
                    _context.FavoriteSuperheroes.Remove(favorite);
                    await _context.SaveChangesAsync();
                    return Ok("Favorite superhero removed.");
                }
            }
            return NotFound("Favorite superhero not found.");
        }
    }
}
