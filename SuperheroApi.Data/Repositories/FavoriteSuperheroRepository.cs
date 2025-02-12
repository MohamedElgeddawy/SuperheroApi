using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Models;
using SuperheroApi.Core;
using SuperheroApi.Data.Data;

namespace SuperheroApi.Data.Repositories
{
    public class FavoriteSuperheroRepository : GenericRepository<FavoriteSuperhero>, IFavoriteSuperheroRepository
    {
        private readonly ApiDbContext _context;
        private readonly ILogger<FavoriteSuperheroRepository> _logger;

        public FavoriteSuperheroRepository(ApiDbContext context, ILogger<FavoriteSuperheroRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<FavoriteSuperhero?> GetBySuperheroIdAsync(int superheroId)
        {
            _logger.LogInformation("Fetching favorite superhero with ID {SuperheroId}", superheroId);
            return await _context.FavoriteSuperheroes
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.SuperheroId == superheroId);
        }

        public async Task<FavoriteSuperhero?> GetByNameAsync(string name)
        {
            _logger.LogInformation("Fetching favorite superhero with name {Name}", name);
            return await _context.FavoriteSuperheroes
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Superhero.Name.ToLower() == name.ToLower()); // Assuming Superhero has a Name property
        }

        public async Task<List<FavoriteSuperhero>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all favorite superheroes.");
            return await _context.FavoriteSuperheroes.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(FavoriteSuperhero favoriteSuperhero)
        {
            _logger.LogInformation("Adding superhero with ID {SuperheroId} to favorites.", favoriteSuperhero.SuperheroId);
            await _context.FavoriteSuperheroes.AddAsync(favoriteSuperhero);
            await _context.SaveChangesAsync();
        }
        public async Task<List<FavoriteSuperhero>> GetFavoritesAsync()
        {
            return await GetAllAsync();
        }

        public async Task DeleteAsync(FavoriteSuperhero favoriteSuperhero)
        {
            _logger.LogInformation("Deleting superhero with ID {SuperheroId} from favorites.", favoriteSuperhero.SuperheroId);
            _context.FavoriteSuperheroes.Remove(favoriteSuperhero);
            await _context.SaveChangesAsync();
        }


      
        
    }
}
