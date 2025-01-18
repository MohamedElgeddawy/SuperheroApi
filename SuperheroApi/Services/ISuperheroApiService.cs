namespace SuperheroApi.Services
{
    public interface ISuperheroApiService
    {
        Task<Superhero> GetSuperheroByIdAsync(int id);
        Task AddFavoriteSuperheroAsync(int superheroId);
    }
}
