using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using SuperheroApi.Core;
using SuperheroApi.Data;
using SuperheroApi.Models;

namespace SuperheroApi.Services
{
   

public class SuperheroApiService : ISuperheroApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly ApiDbContext _context;
        private readonly IMemoryCache _cache;

        public SuperheroApiService(HttpClient httpClient, IConfiguration configuration, ApiDbContext context, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _apiKey = configuration["SuperheroApi:ApiKey"];
            _baseUrl = configuration["SuperheroApi:BaseUrl"];
            _context = context;
            _cache = cache;
        }

        public async Task<Superhero> GetSuperheroByIdAsync(int id)
        {
            var cacheKey = $"Superhero_{id}";
            if (!_cache.TryGetValue(cacheKey, out Superhero superhero))
            {
                var url = $"{_baseUrl}/{_apiKey}/{id}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    superhero = await response.Content.ReadFromJsonAsync<Superhero>();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                    _cache.Set(cacheKey, superhero, cacheEntryOptions);
                }
            }

            return superhero;
        }

        public async Task AddFavoriteSuperheroAsync(int superheroId)
        {
            var url = $"{_baseUrl}/{_apiKey}/{superheroId}";
            var apiResponse = await _httpClient.GetFromJsonAsync<SuperheroResponse>(url);

            if (apiResponse == null)
            {
                throw new Exception("Superhero not found in the API.");
            }

            var superhero = apiResponse.MapApiResponseToSuperhero(apiResponse);

            var existingFavorite = await _context.FavoriteSuperheroes
                .Include(f => f.Superhero)
                .FirstOrDefaultAsync(f => f.Superhero.Name == superhero.Name);

            if (existingFavorite != null)
            {
                throw new Exception("Superhero already exists in the favorite list.");
            }

            var existingSuperhero = await _context.Superheroes
                .FirstOrDefaultAsync(s => s.Name == superhero.Name);

            if (existingSuperhero != null)
            {
                await AddToFavoriteSuperheroesAsync(existingSuperhero);
                return;
            }

            await AddNewSuperheroAsync(superhero);
        }

        private async Task AddToFavoriteSuperheroesAsync(Superhero existingSuperhero)
        {
            var favoriteSuperhero = new FavoriteSuperhero
            {
                SuperheroId = existingSuperhero.Id,
                Superhero = existingSuperhero
            };
            _context.FavoriteSuperheroes.Add(favoriteSuperhero);
            await _context.SaveChangesAsync();
        }

        private async Task AddNewSuperheroAsync(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                await _context.SaveChangesAsync();

                superhero.Powerstats.SuperheroId = superhero.Id;
                superhero.Biography.SuperheroId = superhero.Id;
                superhero.Appearance.SuperheroId = superhero.Id;
                superhero.Work.SuperheroId = superhero.Id;
                superhero.Connections.SuperheroId = superhero.Id;
                superhero.Image.SuperheroId = superhero.Id;

                await _context.SaveChangesAsync();

                await AddToFavoriteSuperheroesAsync(superhero);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving superhero: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }

     

}
