namespace AvoanteDigital.Domain.Entities;

public abstract class Entity
{
    public virtual Guid Id { get; set; }
    public virtual DateTime CreatedAt { get; } = DateTime.UtcNow;
}