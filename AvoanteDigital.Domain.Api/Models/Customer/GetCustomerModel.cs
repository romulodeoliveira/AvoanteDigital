namespace AvoanteDigital.Domain.Api.Models.Customer;

public class GetCustomerModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public String Email { get; set; }
    
    public string TelephoneNumber { get; set;}
    
    public DateTime CreatedAt { get; set; }
}