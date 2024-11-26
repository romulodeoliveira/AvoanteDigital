namespace AvoanteDigital.Domain.Entities;

public class Campaign : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public byte[] Ebook { get; set; }
}