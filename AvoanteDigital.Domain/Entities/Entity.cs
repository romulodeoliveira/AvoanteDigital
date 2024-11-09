namespace AvoanteDigital.Domain.Entities;

public abstract class Entity: IEquatable<Entity>
{
    public Entity(Guid id)
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public bool Equals(Entity other)
    {
        return Id == (other.Id);
    }
}