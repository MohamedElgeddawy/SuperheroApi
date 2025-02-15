 using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.Data;
using SuperheroApi.Core.Models;
using SuperheroApi.Service.IServices;
using SuperheroApi.Core.DTOs;

namespace SuperheroApi.Service.Services
{
    public class AuthService(UserManager<AppUser> userManager, IJwtTokenService jwtTokenService) : IAuthService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

        public async Task<ServiceResponse<string>> RegisterAsync(RegisterRequest model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return new ServiceResponse<string> { IsSuccess = false, Message = "User already exists." };

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new ServiceResponse<string> { IsSuccess = false, Message = "User registration failed." };

            var token = _jwtTokenService.GenerateToken(user);
            return new ServiceResponse<string> { IsSuccess = true, Data = token, Message = "User registered successfully." };
        }


        public async Task<ServiceResponse<string>> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new ServiceResponse<string>("Invalid credentials.", false, "The email or password is incorrect.");

            }

            var token = _jwtTokenService.GenerateToken(user);
            return new ServiceResponse<string>(token, true, "Login successful.");
        }
    }

}
