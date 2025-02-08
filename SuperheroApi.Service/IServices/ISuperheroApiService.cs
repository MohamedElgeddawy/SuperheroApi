using SuperheroApi.Core.Models;

namespace SuperheroApi.Service.IServices
{
    public interface ISuperheroApiService
    {
        Task<Superhero> GetSuperheroByIdAsync(int id);
        Task AddFavoriteSuperheroAsync(int superheroId);
    }
}
