namespace Blogging.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> Get();
    Task<T> Get(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}