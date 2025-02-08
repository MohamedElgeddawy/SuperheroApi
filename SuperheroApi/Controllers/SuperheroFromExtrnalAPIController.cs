using Microsoft.AspNetCore.Mvc;
using SuperheroApi.Core.Models;
using SuperheroApi.Data;
using SuperheroApi.Data.Data;
using SuperheroApi.Service.IServices;

namespace SuperheroApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroFromExtrnalAPIController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISuperheroApiService _superheroApiService;
        private readonly ApiDbContext _context;

        public SuperheroFromExtrnalAPIController(HttpClient httpClient, ISuperheroApiService superheroApiService, ApiDbContext context)
        {
            _httpClient = httpClient;
            _superheroApiService = superheroApiService;
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperhero(int id)
        {
            var superhero = await _superheroApiService.GetSuperheroByIdAsync(id);
            if (superhero == null)
            {
                return NotFound(new { message = "Superhero not found" });
            }

            return Ok(superhero);
        }

        [HttpPost("addFavorite/{superheroId}")]
        public async Task<IActionResult> AddFavoriteSuperhero(int superheroId)
        {
            try
            {
                await _superheroApiService.AddFavoriteSuperheroAsync(superheroId);
                return Ok("Superhero added to favorites.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Superhero not found"))
                {
                    return NotFound(ex.Message);
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}