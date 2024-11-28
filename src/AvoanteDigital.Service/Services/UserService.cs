using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;
using AvoanteDigital.Infra.Repository;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Validators;
using Microsoft.Extensions.Configuration;

namespace AvoanteDigital.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<(bool, string)> CheckCredentialsAsync(string emailFromRequest, string passwordFromRequest)
    {
        try
        {
            var user = await _repository.SelectUserAsync(emailFromRequest);
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