using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AvoanteDigital.Domain.Helper;

namespace AvoanteDigital.Domain.ValueObjects;

public class Password
{
    [NotMapped]
    public string PasswordLiteral { get; set; }
    public byte[] Hash { get; private set; }
    public byte[] Salt { get; private set; }

    public Password() { }

    public Password(string password)
    {
        PasswordLiteral = password;
        SetPassword(password);
    }

    public void SetPassword(string password)
    {
        PasswordLiteral = password;
        PasswordHelper.CreatePasswordHash(password, out byte[] hash, out byte[] salt);
        Hash = hash;
        Salt = salt;
    }
}