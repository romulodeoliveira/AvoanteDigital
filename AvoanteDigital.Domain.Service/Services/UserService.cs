using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;
using AvoanteDigital.Domain.Infra.Data.Repository;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Domain.Service.Validators;
using Microsoft.Extensions.Configuration;

namespace AvoanteDigital.Domain.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public (bool, string) CheckCredentials(string emailFromRequest, string passwordFromRequest)
    {
        try
        {
            var user = _repository.SelectUser(emailFromRequest);
            var response = LoginUserValidator.IsValid(user, passwordFromRequest);
                
            return (response.result, response.message);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            throw;
        }
    }
}