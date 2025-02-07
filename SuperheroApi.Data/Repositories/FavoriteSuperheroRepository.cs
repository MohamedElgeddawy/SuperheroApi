using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Data.Data;
using SuperheroApi.Models;

namespace SuperheroApi.Data.Repositories
{
    public class FavoriteSuperheroRepository : GenericRepository<FavoriteSuperhero>, IFavoriteSuperheroRepository
    {
        public FavoriteSuperheroRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<FavoriteSuperhero> Add(FavoriteSuperhero entity)
        {
            // Include related Superhero entities
            entity.Superhero = await _context.Superheroes
                .Include(s => s.Powerstats)
                .Include(s => s.Biography)
                .Include(s => s.Appearance)
                .Include(s => s.Work)
                .Include(s => s.Connections)
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == entity.SuperheroId);

            await _dbSet.AddAsync(entity);
            return entity;
        }

        public override async Task<bool> Delete(FavoriteSuperhero entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<FavoriteSuperhero>> GetFavorites()
        {
            return await _dbSet
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Powerstats)
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Biography)
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Appearance)
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Work)
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Connections)
                .Include(f => f.Superhero)
                    .ThenInclude(s => s.Image)
                .ToListAsync();
        }
    }

}
