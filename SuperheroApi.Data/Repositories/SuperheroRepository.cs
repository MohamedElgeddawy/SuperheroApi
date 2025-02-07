using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Core.Models;
using SuperheroApi.Data.Data;


namespace SuperheroApi.Data.Repositories
{
    public class SuperheroRepository : GenericRepository<Superhero>, ISuperheroRepository
    {
        public SuperheroRepository(ApiDbContext context, ILogger<SuperheroRepository> logger) : base(context, logger)
        {
        }

        public override async Task<Superhero> GetByName(string name)
        {
            var superhero = await _context.Superheroes
                .Include(s => s.Powerstats)
                .Include(s => s.Biography)
                .Include(s => s.Appearance)
                .Include(s => s.Work)
                .Include(s => s.Connections)
                .Include(s => s.Image)
                .FirstOrDefaultAsync(s => s.Name == name);

            return superhero!;
        }
    }

}
