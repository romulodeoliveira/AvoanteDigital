using System.Text;
using AvoanteDigital.Domain.Helper;

namespace AvoanteDigital.Domain.ValueObjects;

public class Password
{
    public byte[] Hash { get; private set; }
    public byte[] Salt { get; private set; }

    private Password() { }

    public Password(string password)
    {
        PasswordHelper.CreatePasswordHash(password, out byte[] hash, out byte[] salt);
        Hash = hash;
        Salt = salt;
    }
}