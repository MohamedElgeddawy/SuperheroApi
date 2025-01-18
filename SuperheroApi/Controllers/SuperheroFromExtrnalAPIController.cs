using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Services;
//using SuperheroApi.Services;

namespace SuperheroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroFromExtrnalAPIController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISuperheroApiService _superheroApiService;
        private readonly ApiDbContext _context;

        public SuperheroFromExtrnalAPIController(HttpClient httpClient, ISuperheroApiService superheroApiService,  ApiDbContext context)
        {
            _httpClient = httpClient;
            _superheroApiService = superheroApiService;
            _context = context;
        }

        //[HttpGet("external/{id}")]
        //public async Task<IActionResult> GetSuperhero(int id)
        //{
        //    var apiKey = "1ad4ae5a4197e592e3f5ffd66f99e113";
        //    var baseUrl = "https://superheroapi.com/api.php";
        //    var url = $"{baseUrl}/{apiKey}/{id}";

        //    try
        //    {
        //        var response = await _httpClient.GetAsync(url);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            return Ok(content);
        //        }
        //        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        {
        //            return NotFound("Superhero not found.");
        //        }
        //        else
        //        {
        //            return StatusCode((int)response.StatusCode, "Error retrieving superhero.");
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
   

        [HttpGet("external/{id}")]
        public async Task<IActionResult> GetSuperhero(int id)
        {
            var response = await _superheroApiService.GetSuperheroByIdAsync(id);

            if (response == null)
            {
                return NotFound("Superhero not found.");
            }

            return Ok(response);
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