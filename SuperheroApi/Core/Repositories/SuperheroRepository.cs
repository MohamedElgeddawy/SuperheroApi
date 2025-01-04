using Microsoft.EntityFrameworkCore;
using SuperheroApi.Data;
using SuperheroApi.Models;

namespace SuperheroApi.Core.Repositories
{
    public class SuperheroRepository : GenericRepository<Superhero>, ISuperheroRepository
    {
        public SuperheroRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public async Task<Superhero> GetByName(string name)
        {
            return await _context.Superheroes.FirstOrDefaultAsync(s => s.Name == name);
        }

    }
    
}
