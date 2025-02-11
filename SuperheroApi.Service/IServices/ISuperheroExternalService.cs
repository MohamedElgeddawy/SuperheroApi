using System.Threading.Tasks;
using SuperheroApi.Core.Models;
using SuperheroApi.Models;
using SuperheroApi.Service.Services;

namespace SuperheroApi.Services.Services;

public interface ISuperheroExternalService
{
    Task<ServiceResponse<Superhero>> FetchSuperheroByIdAsync(int id);
    Task<ServiceResponse<List<FavoriteSuperhero>>> GetFavoritesAsync();
    Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId);
}
