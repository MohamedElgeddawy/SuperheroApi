using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Data.Repositories;
using SuperheroApi.Data;
using SuperheroApi.Data.Data; // Add this using directive


namespace SuperheroApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;

        public ISuperheroRepository Superheroes { get; private set; }

        public IFavoriteSuperheroRepository FavoriteSuperheroes { get; private set; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _superheroLogger = loggerFactory.CreateLogger<SuperheroRepository>();
            var _favoriteSuperheroLogger = loggerFactory.CreateLogger<FavoriteSuperheroRepository>();

            Superheroes = new SuperheroRepository(context, _superheroLogger);
            FavoriteSuperheroes = new FavoriteSuperheroRepository(context, _favoriteSuperheroLogger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}