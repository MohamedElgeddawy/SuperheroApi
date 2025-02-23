using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using SuperheroApi.Models;
using SuperheroApi.Core.Models;
using SuperheroApi.Core;
using SuperheroApi.Service.Services;
using AutoMapper;
using SuperheroApi.Models;
using SuperheroApi.Data.Data;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Core.Models.Superhero;

namespace SuperheroApi.Services.Services;

public class SuperheroExternalService : ISuperheroExternalService
{
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly ILogger<SuperheroExternalService> _logger;
        private readonly IFavoriteSuperheroRepository _favoriteRepo;
        private readonly ISuperheroRepository _superheroRepo;
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        private const string BASE_URL = "https://superheroapi.com/api/1ad4ae5a4197e592e3f5ffd66f99e113/";

        public SuperheroExternalService(
            HttpClient httpClient,
            IMemoryCache cache,
            ILogger<SuperheroExternalService> logger,
            IFavoriteSuperheroRepository favoriteRepo,
            ISuperheroRepository superheroRepo,
            ApiDbContext dbContext,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _cache = cache;
            _logger = logger;
            _favoriteRepo = favoriteRepo;
            _superheroRepo = superheroRepo;
            _dbContext = dbContext;
            _mapper = mapper;
        }



    /// <summary>
    /// Fetches superhero from external API and saves to database if not found.
    /// </summary>
  
    public async Task<ServiceResponse<Superhero>> FetchSuperheroByIdAsync(int id)
    {
        try
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid superhero ID: {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "Invalid ID.");
            }

            string cacheKey = $"Superhero_{id}";

            // ✅ Step 1: Check Cache First
            if (_cache.TryGetValue(cacheKey, out Superhero cachedSuperhero))
            {
                _logger.LogInformation("Returning cached superhero for ID {Id}", id);
                return new ServiceResponse<Superhero>(cachedSuperhero, true, "Superhero retrieved from cache.");
            }

            // ✅ Step 2: Check Database Again
            var existingSuperhero = await _dbContext.Superheroes
                .AsNoTracking()  // Prevents EF Core from caching stale data
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingSuperhero != null)
            {
                _logger.LogInformation("Superhero ID {Id} found in database.", id);
                _cache.Set(cacheKey, existingSuperhero, TimeSpan.FromMinutes(10));
                return new ServiceResponse<Superhero>(existingSuperhero, true, "Superhero retrieved from database.");
            }

            // ✅ Step 3: Fetch from External API
            _logger.LogInformation("Fetching superhero ID {Id} from external API", id);
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}{id}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("External API request failed with status {StatusCode} for ID {Id}", response.StatusCode, id);
                return new ServiceResponse<Superhero>(null, false, "Superhero not found in external API.");
            }

            string rawResponse = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Raw API Response for Superhero ID {Id}: {Response}", id, rawResponse);

            var apiResponse = JsonSerializer.Deserialize<SuperheroApiResponse>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (apiResponse == null || apiResponse.Response == "error")
            {
                _logger.LogError("Superhero API returned an error message for ID {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "Superhero not found.");
            }

            // ✅ Step 4: Ensure Mapped Data is Valid
            var superhero = _mapper.Map<Superhero>(apiResponse);

            if (string.IsNullOrEmpty(superhero.Name))
            {
                _logger.LogError("Mapped superhero object is invalid for ID {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "Invalid data from external API.");
            }

            // ✅ Step 5: Save Superhero to Database and Re-Fetch
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    superhero.Id = 0;
                    _dbContext.Superheroes.Add(superhero);
                    await _dbContext.SaveChangesAsync();

                    // 🔥 **Ensure it's fully saved by re-fetching it**
                    superhero = await _dbContext.Superheroes
                        .AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == superhero.Id);

                    if (superhero == null)
                    {
                        throw new Exception($"Superhero ID {id} failed to save.");
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "Error while saving superhero ID {Id}", id);
                    return new ServiceResponse<Superhero>(null, false, "Database error while saving superhero.");
                }
            }

            // ✅ Step 6: Update Cache
            _cache.Set(cacheKey, superhero, TimeSpan.FromMinutes(10));

            return new ServiceResponse<Superhero>(superhero, true, "Superhero successfully fetched and saved.");
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "JSON deserialization failed for superhero ID {Id}", id);
            return new ServiceResponse<Superhero>(null, false, "Invalid data from external API.");
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error while calling external API for superhero ID {Id}", id);
            return new ServiceResponse<Superhero>(null, false, "External API unavailable.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error while fetching superhero ID {Id}", id);
            return new ServiceResponse<Superhero>(null, false, "An unexpected error occurred.");
        }
    }

    /// <summary>
    /// Add favorite superheroe To database.
    /// </summary>
    //public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    //{
    //    try
    //    {
    //        // ✅ Check if superhero exists in database
    //        var superhero = await _dbContext.Superheroes.FirstOrDefaultAsync(s => s.Id == superheroId);

    //        if (superhero == null)
    //        {
    //            // 🚀 Fetch from external API
    //            var apiResponse = await FetchSuperheroByIdAsync(superheroId);
    //            if (apiResponse.Data == null)  
    //            {
    //                return new ServiceResponse<string>(null, false, $"Superhero ID {superheroId} not found in external API.");
    //            }

    //            superhero = apiResponse.Data;

    //            // ✅ Explicitly start a transaction
    //            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
    //            {
    //                try
    //                {
    //                    // 💾 Save superhero to database first
    //                    _dbContext.Superheroes.Add(superhero);
    //                    await _dbContext.SaveChangesAsync();

    //                    // 🔥 Ensure it's properly tracked
    //                    superhero = await _dbContext.Superheroes.FirstOrDefaultAsync(s => s.Id == superheroId);

    //                    // ✅ Add to favorites in the same transaction
    //                    var favoriteSuperhero = new FavoriteSuperhero { SuperheroId = superhero.Id };
    //                    _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
    //                    await _dbContext.SaveChangesAsync();

    //                    // ✅ Commit transaction
    //                    await transaction.CommitAsync();
    //                }
    //                catch (Exception)
    //                {
    //                    await transaction.RollbackAsync();
    //                    throw;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            // ✅ If superhero exists, just add to favorites
    //            bool alreadyFavorited = await _dbContext.FavoriteSuperheroes.AnyAsync(fav => fav.SuperheroId == superheroId);
    //            if (alreadyFavorited)
    //            {
    //                return new ServiceResponse<string>(null, false, $"Superhero ID {superheroId} is already in favorites.");
    //            }

    //            // 💾 Add to favorites
    //            var favoriteSuperhero = new FavoriteSuperhero
    //            {
    //                SuperheroId = superhero.Id,
    //                SuperheroName = superhero.Name 
    //            };
    //            _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
    //            await _dbContext.SaveChangesAsync();
    //        }

    //        return new ServiceResponse<string>(null, true, $"Superhero ID {superheroId} added to favorites.");
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError($"Error adding superhero {superheroId} to favorites: {ex.Message}");
    //        return new ServiceResponse<string>(null, false, "An error occurred while adding superhero to favorites.");
    //    }
    //}
    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId, string userId)
    {
        try
        {
            // ✅ Check if the superhero exists in the database
            var superhero = await _dbContext.Superheroes.FirstOrDefaultAsync(s => s.Id == superheroId);

            if (superhero == null)
            {
                var apiResponse = await FetchSuperheroByIdAsync(superheroId);
                if (apiResponse.Data == null)
                {
                    return new ServiceResponse<string>(null, false, $"Superhero ID {superheroId} not found in external API.");
                }

                superhero = apiResponse.Data;

                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _dbContext.Superheroes.Add(superhero);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }

            // ✅ Ensure `UserId` is included when adding to favorites
            var favoriteSuperhero = new FavoriteSuperhero
            {
                SuperheroId = superhero.Id,
                SuperheroName = superhero.Name,
                UserId = userId
            };

            _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<string>(null, true, $"Superhero ID {superheroId} added to favorites.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding superhero {superheroId} to favorites: {ex.Message}");
            return new ServiceResponse<string>(null, false, "An error occurred while adding superhero to favorites.");
        }
    }



    /// <summary>
    /// Fetches favorite superheroes from the database.
    /// </summary>
    public async Task<ServiceResponse<List<FavoriteSuperhero>>> GetFavoritesAsync()
    {
        try
        {
            var favorites = await _favoriteRepo.GetFavoritesAsync();

            if (favorites == null || !favorites.Any())
            {
                return new ServiceResponse<List<FavoriteSuperhero>>(null, false, "No favorites found.");
            }

            return new ServiceResponse<List<FavoriteSuperhero>>(favorites, true, "Favorites retrieved successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching favorite superheroes");
            return new ServiceResponse<List<FavoriteSuperhero>>(null, false, "An unexpected error occurred while fetching favorites.");
        }
    }




}
