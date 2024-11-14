namespace AvoanteDigital.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; }
    
    public String Email { get; set; }
    
    public string TelephoneNumber { get; set; }
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
}