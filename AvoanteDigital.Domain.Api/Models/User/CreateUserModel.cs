namespace AvoanteDigital.Domain.Api.Models.User;

public class CreateUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}