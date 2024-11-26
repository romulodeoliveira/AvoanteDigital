using AvoanteDigital.Domain.Enums;
using AvoanteDigital.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace AvoanteDigital.Domain.Entities;

public class User : Entity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public Password Password { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } 
}