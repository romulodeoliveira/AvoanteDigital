namespace AvoanteDigital.Domain.Api.Models.Customer;

public class GetCustomerModel
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public string Name { get; }
    
    public String Email { get; }
    
    public string TelephoneNumber { get; }
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}