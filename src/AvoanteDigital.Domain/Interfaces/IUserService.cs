using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserService
{
    Task<(bool, string)> CheckCredentialsAsync(string email, string password);
    Task<TOutputModel> GetUserByEmailAsync<TOutputModel>(string email) where TOutputModel : class;
}