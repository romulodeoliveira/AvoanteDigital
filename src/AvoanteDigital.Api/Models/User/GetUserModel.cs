namespace AvoanteDigital.Api.Models.User;

public class GetUserModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public int UserRole { get; set; }
    public bool IsActive { get; set; } 
    public DateTime CreatedAt { get; set; }
}