using SuperheroApi.Core.DTOs;
using SuperheroApi.Core.Models;
using SuperheroApi.Core.Models.Superhero;
using SuperheroApi.Models;


namespace SuperheroApi.Services.Services;

public interface ISuperheroExternalService
{
    Task<ServiceResponse<SuperheroDto>> FetchSuperheroByIdAsync(int id);
    Task<ServiceResponse<List<FavoriteSuperhero>>> GetFavoritesAsync();
    Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId);
}
