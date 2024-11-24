using AvoanteDigital.Domain.Entities;

namespace AvoanteDigital.Domain.Interfaces;

public interface IUserService
{
    (bool, string) CheckCredentials(string email, string password);
}