namespace AvoanteDigital.Domain.Entities;

public class Customer : Entity
{
    // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

    public Customer(Guid id, string name, string email, string telephoneNumber, DateTime? updatedAt) : base(id)
    {
        Name = name;
        Email = email;
        TelephoneNumber = telephoneNumber;
        UpdatedAt = updatedAt;
    }

    // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

    public string Name { get; private set; }
    
    public String Email { get; private set; }
    
    public string TelephoneNumber { get; private set; }
    
    // Endereço IP
    
    // Campanha
    
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; private set; }
    
    // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    
    // Método para atualizar o nome
    public void UpdateName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    // Método para atualizar o email
    public void UpdateEmail(string email)
    {
        Email = new string(email);
        UpdatedAt = DateTime.UtcNow;
    }

    // Método para atualizar o número de telefone
    public void UpdateTelephoneNumber(string phone)
    {
        TelephoneNumber = new string(phone);
        UpdatedAt = DateTime.UtcNow;
    }
    
    // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
}