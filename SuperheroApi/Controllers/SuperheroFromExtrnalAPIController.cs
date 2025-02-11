using Microsoft.AspNetCore.Mvc;
using SuperheroApi.Services;
using SuperheroApi.Models;
using System.Threading.Tasks;
using SuperheroApi.Services.Services;

namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroFromExternalAPIController(ISuperheroExternalService _superheroExternalService) : ControllerBase
    {
        /// <summary>
        /// Get a superhero by ID from an external API
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperheroFromExternalAPI(int id)
        {
            var result = await _superheroExternalService.FetchSuperheroByIdAsync(id);

            if (!result.IsSuccess)
            {
                return StatusCode(404, new { message = result.Message });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Get all favorite superheroes
        /// </summary>
        [HttpGet("favorites")]
        public async Task<IActionResult> GetFavorites()
        {
            var result = await _superheroExternalService.GetFavoritesAsync();

            if (!result.IsSuccess)
            {
                return StatusCode(500, new { message = result.Message });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Add a superhero to favorites
        /// </summary>
        [HttpPost("favorites")]
        public async Task<IActionResult> AddFavoriteSuperhero([FromBody] int superheroId)
        {
            var result = await _superheroExternalService.AddFavoriteSuperheroAsync(superheroId);

            if (!result.IsSuccess)
            {
                return StatusCode(400, new { message = result.Message });
            }

            return Ok(new { message = result.Message });
        }

    }
}
