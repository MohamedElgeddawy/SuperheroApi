using SuperheroApi.Models;

namespace SuperheroApi.Core
{
    public interface IFavoriteSuperheroRepository : IGenericRepository<FavoriteSuperhero>
    {
        Task<FavoriteSuperhero?> GetBySuperheroIdAsync(int superheroId);
        Task<List<FavoriteSuperhero>> GetFavoritesAsync();
        Task AddAsync(FavoriteSuperhero favoriteSuperhero);
    }
}
