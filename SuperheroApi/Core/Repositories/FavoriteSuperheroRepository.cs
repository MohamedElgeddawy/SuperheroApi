using Microsoft.EntityFrameworkCore;
using SuperheroApi.Data;
using SuperheroApi.Models;

namespace SuperheroApi.Core.Repositories
{
    public class FavoriteSuperheroRepository : GenericRepository<FavoriteSuperhero>, IFavoriteSuperheroRepository
    {
        public FavoriteSuperheroRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public async Task<FavoriteSuperhero> Add(FavoriteSuperhero entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }


        public async Task<bool> Delete(FavoriteSuperhero entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }
   
}
