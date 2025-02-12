using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SuperheroApi.Services;
using SuperheroApi.Services.Service;

namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly ISuperheroService _superheroService;

        public SuperheroController(ISuperheroService superheroService)
        {
            _superheroService = superheroService;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperhero(int id)
        {
            var result = await _superheroService.GetSuperheroByIdAsync(id);

            if (!result.IsSuccess)
            {
                return StatusCode(404, new { message = result.Message });
            }

            return Ok(result.Data);
        }

    
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetSuperheroByName(string name)
        {
            var result = await _superheroService.GetSuperheroByNameAsync(name);

            if (!result.IsSuccess)
            {
                return StatusCode(404, new { message = result.Message });
            }

            return Ok(result.Data);
        }

    }
}
