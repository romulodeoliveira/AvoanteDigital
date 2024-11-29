using AutoMapper;
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
    
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

    public async Task<TOutputModel> GetUserByEmailAsync<TOutputModel>(string email) where TOutputModel : class
    {
        var user = await _repository.SelectUserAsync(email);
        var outputModel = _mapper.Map<TOutputModel>(user);
        return outputModel;
    }
}