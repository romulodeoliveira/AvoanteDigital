using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserRepository
{
    void UpdateUser(User user);
    User SelectUser(string email);
}