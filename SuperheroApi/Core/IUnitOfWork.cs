namespace SuperheroApi.Core
{
    public interface IUnitOfWork
    {
        ISuperheroRepository Superheroes { get; }
        IFavoriteSuperheroRepository FavoriteSuperheroes { get; }
        Task CompleteAsync();
    }
}
