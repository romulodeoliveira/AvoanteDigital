using AutoMapper;
using AvoanteDigital.Domain.Entities;
using AvoanteDigital.Domain.Helper;
using AvoanteDigital.Infra.Repository;
using AvoanteDigital.Domain.Interfaces;
using AvoanteDigital.Service.Validators;
using FluentValidation;
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

    public async Task<bool> RegisterAsync<TInputModel, TValidator>(TInputModel model)
        where TValidator : AbstractValidator<User>
        where TInputModel : class
    {
        User user = new User();
        _mapper.Map(model, user);
        await Validate(user, Activator.CreateInstance<TValidator>());
        await _repository.RegisterAsync(user);
        return true;
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

    public async Task<IEnumerable<TOutputModel>> GetUsersAsync<TOutputModel>()
        where TOutputModel : class
    {
        var user  = await _repository.SelectUserAsync();
        var outputModel = user.Select(user => _mapper.Map<TOutputModel>(user)).ToList();
        return outputModel;
    }

    public async Task<TOutputModel> GetUserByEmailAsync<TOutputModel>(string email) where TOutputModel : class
    {
        var user = await _repository.SelectUserAsync(email);
        var outputModel = _mapper.Map<TOutputModel>(user);
        return outputModel;
    }

    public async Task<bool> UpdateUserProfileAsync<TValidator, TInputModel>(TInputModel inputModel, string email)
        where TValidator : AbstractValidator<User>
        where TInputModel : class
    {
        var user = await _repository.SelectUserAsync(email);
        _mapper.Map(inputModel, user);
        await Validate(user, Activator.CreateInstance<TValidator>());
        await _repository.UpdateUserAsync(user);
        return true;
    }

    public async Task<bool> UpdateUserActivityAsync<TValidator, TInputModel>(TInputModel inputModel, string email)
        where TValidator : AbstractValidator<User>
        where TInputModel : class
    {
        var user = await _repository.SelectUserAsync(email);
        _mapper.Map(inputModel, user);
        await Validate(user, Activator.CreateInstance<TValidator>());
        await _repository.UpdateUserAsync(user);
        return true;
    }

    public async Task<bool> DeleteUserAsync(string email)
    {
        await _repository.DeleteAsync(email);
        return true;
    }

private async Task Validate(User obj, AbstractValidator<User> validator)
    {
        if (obj == null)
            throw new Exception("Registros não detectados!");

        validator.ValidateAndThrow(obj);
    }
}