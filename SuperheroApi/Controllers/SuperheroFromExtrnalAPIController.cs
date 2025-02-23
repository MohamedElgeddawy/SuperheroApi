using Microsoft.AspNetCore.Mvc;
using SuperheroApi.Services;
using SuperheroApi.Models;
using System.Threading.Tasks;
using SuperheroApi.Services.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroFromExternalAPIController : ControllerBase
    {
        private readonly ISuperheroExternalService _superheroExternalService;

        public SuperheroFromExternalAPIController(ISuperheroExternalService superheroExternalService)
        {
            _superheroExternalService = superheroExternalService;
        }

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

        [Authorize]
        [HttpPost("favorites")]
        public async Task<IActionResult> AddFavoriteSuperhero(int superheroId)
        {
            // ✅ Retrieve the logged-in user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User must be logged in." });
            }

            // ✅ Pass userId when calling the service
            var result = await _superheroExternalService.AddFavoriteSuperheroAsync(superheroId, userId);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { message = result.Message });
        }
    }
}
