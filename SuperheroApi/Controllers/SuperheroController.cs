using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Data.Data;
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


        // Endpoint to get all information of a character by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperheroById(int id)
        {
            var superhero = await _context.Superheroes.FirstOrDefaultAsync(s => s.Id == id);

            if (superhero == null)
            {
                return NotFound("Superhero not found.");
            }

            return Ok(superhero);
        }
       
    }
}
