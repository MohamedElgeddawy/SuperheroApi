﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Core.Models;
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
    }

}
