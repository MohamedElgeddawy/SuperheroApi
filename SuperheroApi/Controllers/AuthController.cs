
﻿using Microsoft.AspNetCore.Mvc;
using SuperheroApi.Service.IServices;
namespace SuperheroApi.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService; 

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Core.DTOs.RegisterRequest model)
        {
            var result = await _authService.RegisterAsync(model);
            if (!result.IsSuccess)
                return BadRequest(new { Message = result.Message }); 

            return Ok(new { Token = result.Data });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Core.DTOs.LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);

            if (!response.IsSuccess)
                return Unauthorized(response.Message);

            return Ok(new { Token = response.Data });
        }
    }
}
