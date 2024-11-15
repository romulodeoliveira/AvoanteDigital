namespace AvoanteDigital.Domain.Api.Models;

public class CreateCustomerModel
{
    public string Name { get; set; }
    
    public String Email { get; set; }
    
    public string TelephoneNumber { get; set; }
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}