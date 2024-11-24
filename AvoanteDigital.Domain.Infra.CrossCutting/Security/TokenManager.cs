using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AvoanteDigital.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AvoanteDigital.Domain.Infra.CrossCutting.Security;

public class TokenManager : ITokenManager
{
    private readonly string _key;

    public TokenManager(string key)
    {
        _key = key;
    }

    public string CreateToken(User user, IConfiguration configuration)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}