namespace AvoanteDigital.Domain.Entities;

public abstract class Entity
{
    public virtual Guid Id { get; }
    public virtual DateTime CreatedAt { get; } = DateTime.UtcNow;
}