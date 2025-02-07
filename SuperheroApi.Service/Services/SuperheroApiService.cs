using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SuperheroApi.Core.Models;
using SuperheroApi.Models;

namespace SuperheroApi.Service.Services
{
    public class SuperheroApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://superheroapi.com/api/1ad4ae5a4197e592e3f5ffd66f99e113/";

        public SuperheroApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Superhero> GetSuperheroByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null; // Handle failure (return null or throw an exception)
            }

            var json = await response.Content.ReadAsStringAsync();
            var superhero = JsonSerializer.Deserialize<Superhero>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return superhero;
        }
    }
}
