namespace AvoanteDigital.Api.Models.User;

public class CreateUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int UserRole { get; set; }
    public bool IsActive { get; set; } = true;
}