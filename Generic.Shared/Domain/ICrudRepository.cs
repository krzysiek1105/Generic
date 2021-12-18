namespace Generic.Shared.Domain;

public interface ICrudRepository<T> where T : IAggregateRoot
{
    T Create(T entity);
    T Get(Guid id);
    void Update(T entity);
    void Delete(Guid id);
    void Delete(T entity);
    void SaveChanges();
}