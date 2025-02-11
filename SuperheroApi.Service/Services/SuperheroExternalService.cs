using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using SuperheroApi.Models;
using SuperheroApi.Core.Models;
using SuperheroApi.Core;
using SuperheroApi.Service.Services;
using AutoMapper;

// Add the missing using directive for the PowerStats class
using SuperheroApi.Models;
using SuperheroApi.Data.Data;
using Microsoft.EntityFrameworkCore;

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



    /* reun twice
    public async Task<ServiceResponse<Superhero>> FetchSuperheroByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("Invalid superhero ID: {Id}", id);
                    return new ServiceResponse<Superhero>(StatusCodes.Status400BadRequest, "Invalid ID.");
                }

                string cacheKey = $"Superhero_{id}";
                if (_cache.TryGetValue(cacheKey, out Superhero cachedSuperhero))
                {
                    _logger.LogInformation("Returning cached superhero for ID {Id}", id);
                    return new ServiceResponse<Superhero>(StatusCodes.Status200OK, cachedSuperhero);
                }

                // Check database before calling API
                var existingSuperhero = await _superheroRepo.GetByIdAsync(id);
                if (existingSuperhero != null)
                {
                    _logger.LogInformation("Superhero ID {Id} found in database.", id);
                    _cache.Set(cacheKey, existingSuperhero, TimeSpan.FromMinutes(10));
                    return new ServiceResponse<Superhero>(StatusCodes.Status200OK, existingSuperhero);
                }z

                // Fetch from external API
                _logger.LogInformation("Fetching superhero ID {Id} from external API", id);
                HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}{id}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("External API request failed with status {StatusCode} for ID {Id}", response.StatusCode, id);
                    return new ServiceResponse<Superhero>(StatusCodes.Status404NotFound, "Superhero not found in external API.");
                }

                string rawResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Raw API Response for Superhero ID {Id}: {Response}", id, rawResponse);

                var apiResponse = JsonSerializer.Deserialize<SuperheroApiResponse>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse == null || apiResponse.Response == "error")
                {
                    _logger.LogError("Superhero API returned an error message for ID {Id}", id);
                    return new ServiceResponse<Superhero>(StatusCodes.Status404NotFound, "Superhero not found.");
                }

                var superhero = _mapper.Map<Superhero>(apiResponse);
                await _superheroRepo.AddAsync(superhero);
                await _dbContext.SaveChangesAsync();

                _cache.Set(cacheKey, superhero, TimeSpan.FromMinutes(10));
                return new ServiceResponse<Superhero>(StatusCodes.Status200OK, superhero);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "JSON deserialization failed for superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status500InternalServerError, "Invalid data from external API.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Network error while calling external API for superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status503ServiceUnavailable, "External API unavailable.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

    /// <summary>
    /// Adds superhero to favorites
    /// </summary>
    /// 

    
    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    {
        try
        {
            if (superheroId <= 0)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Invalid superhero ID.");
            }

            var existingFavorite = await _favoriteRepo.GetBySuperheroIdAsync(superheroId);
            if (existingFavorite != null)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Superhero is already in favorites.");
            }

            var existingSuperhero = await _superheroRepo.GetByIdAsync(superheroId);
            if (existingSuperhero == null)
            {
                _logger.LogInformation("Superhero ID {Id} not found in database. Fetching from external API...", superheroId);

                var superheroResponse = await FetchSuperheroByIdAsync(superheroId);

                if (superheroResponse?.Data == null)
                {
                    _logger.LogError("Superhero data is null from API response for superhero ID {Id}", superheroId);
                    return new ServiceResponse<string>(StatusCodes.Status404NotFound, "Superhero not found.");
                }

                existingSuperhero = superheroResponse.Data;

                await _superheroRepo.AddAsync(existingSuperhero);
                _logger.LogInformation("Superhero ID {Id} saved to database.", superheroId);
            }

            await _favoriteRepo.AddAsync(new FavoriteSuperhero { SuperheroId = superheroId });

            return new ServiceResponse<string>(StatusCodes.Status200OK, "Superhero added to favorites successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding superhero {SuperheroId} to favorites", superheroId);
            return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }
    */


    /// <summary>
    /// Fetches superhero from external API and saves to database if not found.
    /// </summary>
    /* 2th to add
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
                if (_cache.TryGetValue(cacheKey, out Superhero cachedSuperhero))
                {
                    _logger.LogInformation("Returning cached superhero for ID {Id}", id);
                    return new ServiceResponse<Superhero>(cachedSuperhero, true, "Superhero retrieved from cache.");
                }

                // 🔍 Check if superhero exists in DB before making API call
                var existingSuperhero = await _superheroRepo.GetByIdAsync(id);
                if (existingSuperhero != null)
                {
                    _logger.LogInformation("Superhero ID {Id} found in database.", id);
                    _cache.Set(cacheKey, existingSuperhero, TimeSpan.FromMinutes(10));
                    return new ServiceResponse<Superhero>(existingSuperhero, true, "Superhero retrieved from database.");
                }

                // 🌍 Fetch from external API
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

                // ✅ Ensure required fields exist before saving
                var superhero = _mapper.Map<Superhero>(apiResponse);
                // 🚀 Reset the ID to allow EF Core to generate it
                superhero.Id = 0;
                if (string.IsNullOrEmpty(superhero.Name))
                {
                    _logger.LogError("Mapped superhero object is invalid for ID {Id}", id);
                    return new ServiceResponse<Superhero>(null, false, "Invalid data from external API.");
                }

                // 💾 Save superhero to database
                _dbContext.Superheroes.Add(superhero);
                await _dbContext.SaveChangesAsync();

                // 🔥 Cache superhero
                _cache.Set(cacheKey, superhero, TimeSpan.FromMinutes(10));

                return new ServiceResponse<Superhero>(superhero, true, "Superhero retrieved successfully.");
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
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database update error while adding superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "Database error. Ensure relationships are correctly set.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while fetching superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(null, false, "An unexpected error occurred.");
            }
        }

        public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
        {
            var response = new ServiceResponse<string>(null, false, "Superhero not found.");

            try
            {

                    // 🔎 Check if superhero exists in the database first
                    var superhero = await _dbContext.Superheroes.FindAsync(superheroId);

                    if (superhero == null)
                    {
                        // 🚀 Fetch from external API
                        var apiResponse = await FetchSuperheroByIdAsync(superheroId);

                        if (apiResponse == null || apiResponse.Data == null)  // ✅ Fix Null Check
                        {
                            response.IsSuccess = false;
                            response.Message = $"Superhero ID {superheroId} not found in external API.";
                            return response;
                        }

                        // 🏗️ Map API response to Superhero entity using AutoMapper
                        superhero = _mapper.Map<Superhero>(apiResponse.Data);

                        // 💾 Save superhero to database first ✅
                        _dbContext.Superheroes.Add(superhero);
                        await _dbContext.SaveChangesAsync();  // ✅ Save BEFORE proceeding!
                    }

                    // 🔎 Check if superhero is already in favorites
                    bool alreadyFavorited = await _dbContext.FavoriteSuperheroes
                        .AnyAsync(fav => fav.SuperheroId == superheroId);

                    if (alreadyFavorited)
                    {
                        response.IsSuccess = false;
                        response.Message = $"Superhero ID {superheroId} is already in favorites.";
                        return response;
                    }

                    // 💾 Insert superhero into favorites now that it's tracked ✅
                    var favoriteSuperhero = new FavoriteSuperhero { SuperheroId = superhero.Id };
                    _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
                    await _dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Message = $"Superhero ID {superheroId} added to favorites.";
                    return response;

                }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding superhero {superheroId} to favorites: {ex.Message}");
                response.IsSuccess = false;
                response.Message = "An error occurred while adding superhero to favorites.";
            }

            return response;
        }

        */

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


    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    {
        try
        {
            // ✅ Check if superhero exists in database
            var superhero = await _dbContext.Superheroes.FirstOrDefaultAsync(s => s.Id == superheroId);

            if (superhero == null)
            {
                // 🚀 Fetch from external API
                var apiResponse = await FetchSuperheroByIdAsync(superheroId);
                if (apiResponse.Data == null)  // ✅ Fix Null Check
                {
                    return new ServiceResponse<string>(null, false, $"Superhero ID {superheroId} not found in external API.");
                }

                superhero = apiResponse.Data;

                // ✅ Explicitly start a transaction
                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // 💾 Save superhero to database first
                        _dbContext.Superheroes.Add(superhero);
                        await _dbContext.SaveChangesAsync();

                        // 🔥 Ensure it's properly tracked
                        superhero = await _dbContext.Superheroes.FirstOrDefaultAsync(s => s.Id == superheroId);

                        // ✅ Add to favorites in the same transaction
                        var favoriteSuperhero = new FavoriteSuperhero { SuperheroId = superhero.Id };
                        _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
                        await _dbContext.SaveChangesAsync();

                        // ✅ Commit transaction
                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            else
            {
                // ✅ If superhero exists, just add to favorites
                bool alreadyFavorited = await _dbContext.FavoriteSuperheroes.AnyAsync(fav => fav.SuperheroId == superheroId);
                if (alreadyFavorited)
                {
                    return new ServiceResponse<string>(null, false, $"Superhero ID {superheroId} is already in favorites.");
                }

                // 💾 Add to favorites
                var favoriteSuperhero = new FavoriteSuperhero { SuperheroId = superhero.Id };
                _dbContext.FavoriteSuperheroes.Add(favoriteSuperhero);
                await _dbContext.SaveChangesAsync();
            }

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

    /* 1st
    public async Task<ServiceResponse<Superhero>> FetchSuperheroByIdAsync(int id)
    {
        string rawResponse = string.Empty;

        try
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid superhero ID: {Id}", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status400BadRequest, "Invalid ID.");
            }

            string cacheKey = $"Superhero_{id}";

            if (_cache.TryGetValue(cacheKey, out Superhero cachedSuperhero))
            {
                return new ServiceResponse<Superhero>(StatusCodes.Status200OK, cachedSuperhero);
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}{id}");
            rawResponse = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Raw API Response for Superhero ID {Id}: {ApiResponse}", id, rawResponse);

            // ✅ Ensure the response contains valid JSON
            if (string.IsNullOrWhiteSpace(rawResponse) || !rawResponse.Trim().StartsWith("{"))
            {
                _logger.LogError("API returned an invalid or empty response for Superhero ID {Id}", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status500InternalServerError, "Invalid data received from external API.");
            }

            // ✅ Deserialize JSON response
            var apiResponse = JsonSerializer.Deserialize<SuperheroApiResponse>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (apiResponse == null || apiResponse.Response == "error")
            {
                _logger.LogError("Superhero API returned an error for ID {Id}: {Error}", id, apiResponse?.Error);
                return new ServiceResponse<Superhero>(StatusCodes.Status404NotFound, $"API Error: {apiResponse?.Error}");
            }

            // ✅ Map API response to `Superhero`
            var superhero = _mapper.Map<Superhero>(apiResponse);

            // ✅ Log the mapped superhero object
            _logger.LogInformation("Mapped Superhero Object: {Superhero}", JsonSerializer.Serialize(superhero));

            if (superhero == null)
            {
                _logger.LogError("Mapping failed for superhero ID {Id}. AutoMapper returned null.", id);
                return new ServiceResponse<Superhero>(StatusCodes.Status500InternalServerError, "Mapping failed.");
            }

            _cache.Set(cacheKey, superhero, TimeSpan.FromMinutes(10));
            return new ServiceResponse<Superhero>(StatusCodes.Status200OK, superhero);
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, "JSON deserialization failed. Raw Response: {ApiResponse}", rawResponse);
            return new ServiceResponse<Superhero>(StatusCodes.Status500InternalServerError, "Invalid API response.");
        }
    }
    */



    /*
    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    {
        try
        {
            if (superheroId <= 0)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Invalid superhero ID.");
            }

            //// ✅ Check if _favoriteRepo is null
            //if (_favoriteRepo == null)
            //{
            //    _logger.LogError("Favorite repository is null.");
            //    return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "Internal server error.");
            //}

            //var existingFavorite = await _favoriteRepo.GetBySuperheroIdAsync(superheroId);
            //if (existingFavorite != null)
            //{
            //    return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Superhero is already in favorites.");
            //}

            //// ✅ Check if _superheroRepo is null
            //if (_superheroRepo == null)
            //{
            //    _logger.LogError("Superhero repository is null.");
            //    return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "Internal server error.");
            //}

            // ✅ Check if `_favoriteRepo` is null
            if (_favoriteRepo == null)
            {
                _logger.LogError("FavoriteSuperheroRepository is null. Ensure it is registered in DI.");
                return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "Internal server error.");
            }

            var existingFavorite = await _favoriteRepo.GetBySuperheroIdAsync(superheroId);
            if (existingFavorite != null)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Superhero is already in favorites.");
            }

            var existingSuperhero = await _superheroRepo.GetByIdAsync(superheroId);
            if (existingSuperhero == null)
            {
                _logger.LogInformation("Superhero ID {Id} not found in database. Fetching from external API...", superheroId);

                var superheroResponse = await FetchSuperheroByIdAsync(superheroId);

                // ✅ Check if superheroResponse is null
                if (superheroResponse == null)
                {
                    _logger.LogError("FetchSuperheroByIdAsync returned null for superhero ID {Id}", superheroId);
                    return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "Failed to retrieve superhero from API.");
                }

                // ✅ Check if superheroResponse.Data is null
                if (superheroResponse.Data == null)
                {
                    _logger.LogError("Superhero data is null from API response for superhero ID {Id}", superheroId);
                    return new ServiceResponse<string>(StatusCodes.Status404NotFound, "Superhero not found.");
                }

                existingSuperhero = superheroResponse.Data;

                // ✅ Save superhero to database
                await _superheroRepo.AddAsync(existingSuperhero);
                _logger.LogInformation("Superhero ID {Id} saved to database.", superheroId);
            }

            // ✅ Add superhero to favorites
            await _favoriteRepo.AddAsync(new FavoriteSuperhero { SuperheroId = superheroId });

            return new ServiceResponse<string>(StatusCodes.Status200OK, "Superhero added to favorites successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding superhero {SuperheroId} to favorites", superheroId);
            return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }
    */

    /*  1 st 
    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    {
        try
        {
            if (superheroId <= 0)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Invalid superhero ID.");
            }

            // ✅ Check if `_favoriteRepo` is null
            if (_favoriteRepo == null)
            {
                _logger.LogError("FavoriteSuperheroRepository is null. Ensure it is registered in DI.");
                return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "Internal server error.");
            }

            var existingFavorite = await _favoriteRepo.GetBySuperheroIdAsync(superheroId);
            if (existingFavorite != null)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Superhero is already in favorites.");
            }

            var existingSuperhero = await _superheroRepo.GetByIdAsync(superheroId);
            if (existingSuperhero == null)
            {
                _logger.LogInformation("Superhero ID {Id} not found in database. Fetching from external API...", superheroId);

                var superheroResponse = await FetchSuperheroByIdAsync(superheroId);

                if (superheroResponse?.Data == null)
                {
                    _logger.LogError("Superhero data is null from API response for superhero ID {Id}", superheroId);
                    return new ServiceResponse<string>(StatusCodes.Status404NotFound, "Superhero not found.");
                }

                existingSuperhero = superheroResponse.Data;

                // ✅ Save superhero to database
                await _superheroRepo.AddAsync(existingSuperhero);
                _logger.LogInformation("Superhero ID {Id} saved to database.", superheroId);
            }

            // ✅ Add superhero to favorites
            await _favoriteRepo.AddAsync(new FavoriteSuperhero { SuperheroId = superheroId });

            return new ServiceResponse<string>(StatusCodes.Status200OK, "Superhero added to favorites successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding superhero {SuperheroId} to favorites", superheroId);
            return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }


    */



    /*
    public async Task<ServiceResponse<string>> AddFavoriteSuperheroAsync(int superheroId)
    {
        try
        {
            if (superheroId <= 0)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Invalid superhero ID.");
            }

            var existingFavorite = await _favoriteRepo.GetBySuperheroIdAsync(superheroId);

            if (existingFavorite != null)
            {
                return new ServiceResponse<string>(StatusCodes.Status400BadRequest, "Superhero is already in favorites.");
            }

            var superheroResponse = await FetchSuperheroByIdAsync(superheroId);

            if (superheroResponse.Data == null)
            {
                _logger.LogError("Superhero data is null from API response for superhero ID {Id}", superheroId);
                return new ServiceResponse<string>(StatusCodes.Status404NotFound, "Superhero not found.");
            }

            var superhero = superheroResponse.Data;

            superhero.Id = 0; // ✅ Ensure that EF Core generates the ID instead of inserting it explicitly

            await _superheroRepo.AddAsync(superhero);

            await _favoriteRepo.AddAsync(new FavoriteSuperhero { SuperheroId = superheroId });

            return new ServiceResponse<string>(StatusCodes.Status200OK, "Superhero added to favorites successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding superhero {SuperheroId} to favorites", superheroId);
            return new ServiceResponse<string>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }

    */



}
