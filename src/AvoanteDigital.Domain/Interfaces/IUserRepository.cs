using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    Task UpdateUserAsync(User user);
    Task<IEnumerable<User>> SelectUserAsync();
    Task <User> SelectUserAsync(string email);
    Task DeleteAsync(string email);
}