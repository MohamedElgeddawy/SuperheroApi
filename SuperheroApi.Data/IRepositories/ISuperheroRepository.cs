using SuperheroApi.Core.Models;
namespace SuperheroApi.Core
{
    public interface ISuperheroRepository : IGenericRepository<Superhero>
    {
        Task<Superhero> GetByIdAsync(int id);
        Task<Superhero> GetByNameAsync(string name);
    }
}
