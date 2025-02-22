﻿using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using SuperheroApi.Core.Models;
using SuperheroApi.Core;
using SuperheroApi.Services.Service;
using SuperheroApi.Core.Models.Superhero;

namespace SuperheroApi.Service.Services
{
    public class SuperheroService : ISuperheroService
    {
        private readonly ISuperheroRepository _repository;
        private readonly ILogger<SuperheroService> _logger;

        public SuperheroService(ISuperheroRepository repository, ILogger<SuperheroService> logger)
        {
            _repository = repository;
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

                var superhero = await _repository.GetByIdAsync(id);

                if (superhero == null)
                {
                    _logger.LogWarning("Superhero with ID {Id} not found.", id);
                    return new ServiceResponse<Superhero>(null, false, $"Superhero with ID {id} not found.");
                }

                return new ServiceResponse<Superhero>(superhero, true, "Superhero retrieved successfully.");
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

                var superhero = await _repository.GetByNameAsync(name);

                if (superhero == null)
                {
                    _logger.LogWarning("Superhero with name {Name} not found.", name);
                    return new ServiceResponse<Superhero>(null, false, $"Superhero with name '{name}' not found.");
                }

                return new ServiceResponse<Superhero>(superhero, true, "Superhero retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving superhero with name {Name}", name);
                return new ServiceResponse<Superhero>(null, false, "An unexpected error occurred.");
            }
        }

    }
}
