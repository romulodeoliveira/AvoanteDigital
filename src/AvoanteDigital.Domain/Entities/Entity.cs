namespace AvoanteDigital.Domain.Entities;

public abstract class Entity
{
    public virtual Guid Id { get; init; }
    public virtual DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}