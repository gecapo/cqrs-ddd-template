namespace CqrsDddTemplate.Domain.Abstractions;

public abstract class Entity<T>
{
    public T Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; protected set; }
}