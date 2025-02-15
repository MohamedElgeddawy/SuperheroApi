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
    public class FavoriteSuperheroController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly ApiDbContext _context;

        // Constructor that accepts the database context
        public FavoriteSuperheroController(IUnitOfWork unitOfWork, ApiDbContext context)
        {
            _unitOfwork = unitOfWork;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // Endpoint to search for superheroes by name
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchSuperhero(string name)
        {
            try
            {
                var result = await _unitOfwork.Superheroes.GetByName(name);
                if (result == null)
                {
                    return NotFound("Superhero not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (logging code not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching for the superhero.");
            }
        }
        [Authorize(Roles = "User")]
        // Endpoint to add a favorite superhero
        [HttpPost("AddFavorites")]
        public async Task<IActionResult> AddFavorite([FromBody] string superheroName)
        {
            try
            {
                var result = await _unitOfwork.Superheroes.GetByName(superheroName);
                if (result == null)
                {
                    return NotFound("Superhero not found.");
                }
                var favoriteExists = await _context.FavoriteSuperheroes.AnyAsync(f => f.SuperheroId == result.Id);
                if (favoriteExists)
                {
                    return BadRequest("Superhero already in favorites.");
                }

                var favoriteSuperhero = new FavoriteSuperhero
                {
                    SuperheroId = result.Id,
                    Superhero = result
                };

                _context.FavoriteSuperheroes.Add(favoriteSuperhero);
                await _context.SaveChangesAsync();
                return Created("", favoriteSuperhero);
            }
            catch (Exception ex)
            {
                // Log the exception (logging code not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the favorite superhero.");
            }
        }
        

        // Endpoint to get the list of favorite superheroes
        [HttpGet("GetFavorites")]
        public async Task<IActionResult> GetFavorites()
        {
            try
            {
                var favorites = await _unitOfwork.FavoriteSuperheroes.GetFavorites();
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                // Log the exception (logging code not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the favorite superheroes.");
            }
        }

        // Endpoint to Delete superheroe by name of favoritesuperheroes
        [HttpDelete("favorites/{name}")]
        public async Task<IActionResult> DeleteFavorite(string name)
        {
            try
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
                    return NotFound("Favorite superhero not found in favorites.");
                }
                return NotFound("Superhero not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (logging code not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the favorite superhero.");
            }
        }
    }
}
