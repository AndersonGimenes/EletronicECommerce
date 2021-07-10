using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Infrastructure.Config;
using Microsoft.IdentityModel.Tokens;

namespace EletronicECommerce.Infrastructure.Security
{
    public static class TokenHandler
    {
        public static string GenerateToken(User user)
        {
            var expiry = DateTime.Now.AddHours(2);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SecurityTokenKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Identifier.ToString())
            };

            var token = new JwtSecurityToken(expires: expiry, signingCredentials: credentials, claims: claims, issuer: Settings.Issuer);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}