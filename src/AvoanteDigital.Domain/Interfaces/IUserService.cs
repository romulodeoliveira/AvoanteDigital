using AvoanteDigital.Domain.Entities;
using FluentValidation;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserService
{
    Task<bool> RegisterAsync<TInputModel, TValidator>(TInputModel inputModel)
        where TValidator : AbstractValidator<User>
        where TInputModel : class;
    
    Task<(bool, string)> CheckCredentialsAsync(string email, string password);
    
    Task<IEnumerable<TOutputModel>> GetUsersAsync<TOutputModel>() 
        where TOutputModel : class;
    
    Task<TOutputModel> GetUserByEmailAsync<TOutputModel>(string email) where TOutputModel : class;
    
    Task<bool> UpdateUserProfileAsync<TValidator, TInputModel>(TInputModel inputModel, string email)
        where TValidator : AbstractValidator<User>
        where TInputModel : class;
    
    Task<bool> UpdateUserActivityAsync<TValidator, TInputModel>(TInputModel inputModel, string email)
        where TValidator : AbstractValidator<User>
        where TInputModel : class;
    
    Task<bool> DeleteUserAsync(string email);
}