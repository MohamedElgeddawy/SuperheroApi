using SuperheroApi.Core.Models;
using SuperheroApi.Core.Models.Superhero;
using SuperheroApi.Service.Services;
using System.Threading.Tasks;

namespace SuperheroApi.Services.Service
{
    public interface ISuperheroService
    {
        Task<ServiceResponse<Superhero>> GetSuperheroByIdAsync(int id);
        Task<ServiceResponse<Superhero>> GetSuperheroByNameAsync(string name);
    }
}
