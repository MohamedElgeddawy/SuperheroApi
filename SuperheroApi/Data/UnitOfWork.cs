using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Core.Repositories;

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
            var _logger = loggerFactory.CreateLogger("UnitOfWork");

            Superheroes = new SuperheroRepository(context, _logger);
            FavoriteSuperheroes = new FavoriteSuperheroRepository(context, _logger);
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
