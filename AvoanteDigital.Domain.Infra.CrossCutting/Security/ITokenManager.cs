using AvoanteDigital.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace AvoanteDigital.Domain.Infra.CrossCutting.Security;

public interface ITokenManager
{
    string CreateToken(User user, IConfiguration configuration);
}