using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentACarProject.Application.Abstraction.Token;
using RentACarProject.Application.ViewModel.Token;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Token CreateAccessToken(AppUser user,int minute = 5)
        {
            Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingcredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingcredentials,
                claims: new List<Claim> { new(ClaimTypes.Email,user.Email) }
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
