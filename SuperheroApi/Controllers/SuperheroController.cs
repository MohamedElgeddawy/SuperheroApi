<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SuperheroApi.Services;
using SuperheroApi.Services.Service;
using Microsoft.AspNetCore.Authorization;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Models;


>>>>>>> e85ae720da2a1dd1cdf9ff192fecd25b12ce94dc

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

<<<<<<< HEAD
        
=======
        [Authorize]
        // Endpoint to get all information of a character by ID
>>>>>>> e85ae720da2a1dd1cdf9ff192fecd25b12ce94dc
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
