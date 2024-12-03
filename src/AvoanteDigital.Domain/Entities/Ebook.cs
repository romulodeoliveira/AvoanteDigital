namespace AvoanteDigital.Domain.Entities;

public class Ebook : Entity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public byte[] PDF { get; set; }
}