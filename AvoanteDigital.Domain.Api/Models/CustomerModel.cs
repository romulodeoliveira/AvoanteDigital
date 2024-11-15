namespace AvoanteDigital.Domain.Api.Models;

public class CustomerModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    
    public String Email { get; set; }
    
    public string TelephoneNumber { get; set; }
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}