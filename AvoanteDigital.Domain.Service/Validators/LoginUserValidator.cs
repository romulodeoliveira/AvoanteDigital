using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;

namespace AvoanteDigital.Domain.Service.Validators;

public class LoginUserValidator
{
    public static (bool result, string message) IsValid<T>(T user, string passwordFromRequest)
        where T : User
    {
        if (user == null)
        {
            return (false, "Credenciais inválidas");
        }
        else
        {
            bool passwordChecked = PasswordHelper.VerifyPasswordHash(
                passwordFromRequest,
                user.Password.Hash,
                user.Password.Salt
            );

            if (passwordChecked)
            {
                return (false, "Credenciais inválidas");
            }
            else
            {
                string token = TokenHelper.CreateToken(user);
                return (true, token);
            }
        }
    }
}