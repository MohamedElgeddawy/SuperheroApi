namespace SuperheroApi.Core
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetByName(string name);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Delete(T entity);
    }
}
