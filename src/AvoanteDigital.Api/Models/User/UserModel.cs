namespace AvoanteDigital.Api.Models.User;

public class UserModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int UserRole { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}