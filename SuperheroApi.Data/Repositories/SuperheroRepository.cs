using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Core.Models.Superhero;
using SuperheroApi.Data.Data;


namespace SuperheroApi.Data.Repositories
{
    public class SuperheroRepository : GenericRepository<Superhero>, ISuperheroRepository
    {
        private readonly ApiDbContext _context;

        public SuperheroRepository(ApiDbContext context, ILogger<SuperheroRepository> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<Superhero> GetByIdAsync(int id)
        {
            return await _context.Superheroes.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Superhero> GetByNameAsync(string name)
        {
            return await _context.Superheroes.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }
        public async Task AddAsync(Superhero superhero)
        {
            if (superhero == null) throw new ArgumentNullException(nameof(superhero));

            superhero.Id = 0; 

            _context.Superheroes.Add(superhero);
            await _context.SaveChangesAsync();
        }
    }

}
