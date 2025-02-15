using Microsoft.AspNetCore.Identity.Data;
using SuperheroApi.Core.DTOs;
using SuperheroApi.Core.Models;

namespace SuperheroApi.Service.IServices
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> RegisterAsync(Core.DTOs.RegisterRequest request);
        Task<ServiceResponse<string>> LoginAsync(Core.DTOs.LoginRequest request);
    }
}