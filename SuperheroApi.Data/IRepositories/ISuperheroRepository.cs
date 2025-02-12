using SuperheroApi.Core.Models.Superhero;
namespace SuperheroApi.Core
{
    public interface ISuperheroRepository : IGenericRepository<Superhero>
    {
        Task AddAsync(Superhero existingSuperhero);
        Task<Superhero> GetByIdAsync(int id);
        Task<Superhero> GetByNameAsync(string name);
    }
}
