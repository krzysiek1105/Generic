namespace Generic.Shared.Domain;

public abstract class Entity
{
    public Guid Id { get; }
    public DateTime CreationDateTime { get; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreationDateTime = DateTime.UtcNow;
    }
}