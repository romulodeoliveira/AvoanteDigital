using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserRepository
{
    Task UpdateUserAsync(User user);
    Task <User> SelectUserAsync(string email);
}