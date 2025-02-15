using SuperheroApi.Core.Models;

namespace SuperheroApi.Service.IServices
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser user);
    }
}