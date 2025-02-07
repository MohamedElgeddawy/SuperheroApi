using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Data.Data;

namespace SuperheroApi.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<T> GetByName(string name)
        {
            // search by name
            return await _dbSet.FirstOrDefaultAsync();
        }
        public virtual async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }


}
