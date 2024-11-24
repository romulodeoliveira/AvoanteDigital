using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;
using AvoanteDigital.Domain.Infra.Data.Repository;
using AvoanteDigital.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AvoanteDigital.Domain.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public (bool, string) CheckCredentials(string email, string password)
    {
        try
        {
            var user = _repository.SelectUser(email);

            if (user == null)
            {
                return (false, "Credenciais inválidas");
            }
            else
            {
                bool passwordChecked = PasswordHelper.VerifyPasswordHash(
                    password,
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
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            throw;
        }
    }
}