using Microsoft.Extensions.Logging;
using SuperheroApi.Core;
using SuperheroApi.Core.Models;
using SuperheroApi.Core.Models.Superhero;
using SuperheroApi.Service.IServices;
using System;
using System.Threading.Tasks;

namespace SuperheroApi.Services.Service
{
    public class SuperheroService : ISuperheroService
    {
        private readonly ISuperheroRepository _repository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<SuperheroService> _logger;

        public SuperheroService(ISuperheroRepository repository, ICacheService cacheService, ILogger<SuperheroService> logger)
        {
            _repository = repository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<ServiceResponse<Superhero>> GetSuperheroByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new ServiceResponse<Superhero>(null, false, "Invalid ID. ID must be greater than zero.");
                }

                string cacheKey = $"Superhero_Id_{id}";
                var cachedSuperhero = _cacheService.Get<ServiceResponse<Superhero>>(cacheKey);
                if (cachedSuperhero != null)
                {
                    _logger.LogInformation("Cache hit for superhero ID {Id}.", id);
                    return cachedSuperhero;
                }

                var superhero = await _repository.GetByIdAsync(id);

                if (superhero == null)
                {
                    _logger.LogWarning("Superhero with ID {Id} not found.", id);
                    return new ServiceResponse<Superhero>(null, false, $"Superhero with ID {id} not found.");
                }

                var response = new ServiceResponse<Superhero>(superhero, true, "Superhero retrieved successfully.");
                _cacheService.Set(cacheKey, response, TimeSpan.FromMinutes(60));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving superhero with ID {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "An unexpected error occurred.");
            }
        }

        public async Task<ServiceResponse<Superhero>> GetSuperheroByNameAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return new ServiceResponse<Superhero>(null, false, "Superhero name cannot be empty.");
                }

                string cacheKey = $"Superhero_Name_{name}";
                var cachedSuperhero = _cacheService.Get<ServiceResponse<Superhero>>(cacheKey);
                if (cachedSuperhero != null)
                {
                    _logger.LogInformation("Cache hit for superhero name {Name}.", name);
                    return cachedSuperhero;
                }

                var superhero = await _repository.GetByNameAsync(name);

                if (superhero == null)
                {
                    _logger.LogWarning("Superhero with name {Name} not found.", name);
                    return new ServiceResponse<Superhero>(null, false, $"Superhero with name '{name}' not found.");
                }

                var response = new ServiceResponse<Superhero>(superhero, true, "Superhero retrieved successfully.");
                _cacheService.Set(cacheKey, response, TimeSpan.FromMinutes(60));

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving superhero with name {Name}", name);
                return new ServiceResponse<Superhero>(null, false, "An unexpected error occurred.");
            }
        }
    }
}
