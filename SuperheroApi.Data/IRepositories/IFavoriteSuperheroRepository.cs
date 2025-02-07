using SuperheroApi.Models;

namespace SuperheroApi.Core
{
    public interface IFavoriteSuperheroRepository : IGenericRepository<FavoriteSuperhero>
    {
        Task<IEnumerable<FavoriteSuperhero>> GetFavorites();
    }
}
