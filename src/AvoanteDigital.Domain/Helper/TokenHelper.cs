using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AvoanteDigital.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AvoanteDigital.Domain.Helper;

public class TokenHelper
{
    public static string Key = "uBMbQErWn&hP7mW5TKa9WisaxTU4EgvG$ZWoFj92Te#NvQmB!Xag$Emzb&eQc7zSkVxWkkb7G&dt9GNpENx7HJfsb*&DHyQvkJW6*e*fvDkrHPT@cem49@*&HRKLGp$e";

    public static string CreateToken(User user)
    {
        // https://jwt.io/
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim("IsActive", user.IsActive.ToString())
        };

        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Key));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}