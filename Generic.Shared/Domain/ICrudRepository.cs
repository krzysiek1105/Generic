namespace Generic.Shared.Domain;

public interface ICrudRepository<T> where T : IAggregateRoot
{
    Task<T> Create(T entity);
    Task<T?> Get(Guid id);
    Task<bool> Exists(Guid id);
    Task Update(T entity);
    Task Delete(Guid id);
    Task Delete(T entity);
    Task SaveChanges();
}