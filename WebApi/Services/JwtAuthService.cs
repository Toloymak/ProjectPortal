using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;
using WebApi.Models.Configs;

namespace WebApi.Services
{
    public interface IJwtAuthService
    {
        JwtAuthResult GenerateToken(string userName, Claim[] claims, DateTime now);
    }

    public class JwtAuthService : IJwtAuthService
    {
        private readonly JwtTokenConfig _jwtTokenConfig;

        public JwtAuthService(JwtTokenConfig jwtTokenConfig)
        {
            _jwtTokenConfig = jwtTokenConfig;
        }

        public JwtAuthResult GenerateToken(string userName, Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = string
               .IsNullOrWhiteSpace(claims?
                                      .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?
                                      .Value); 

            var expiredAt = now.AddMinutes(_jwtTokenConfig.AccessTokenExpiration);

            var jwtToken = new JwtSecurityToken(
                _jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: expiredAt,
                signingCredentials: new SigningCredentials(_jwtTokenConfig.SymmetricSecurityKey,
                                                           SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new JwtAuthResult()
            {
                AccessToken = Guid.NewGuid().ToString(),
                AuthTokenMetadata = new AuthMetadata()
                {
                    ExpireAt = DateTime.Today.AddDays(1),
                    UserName = "User_" + Guid.NewGuid().ToString()
                }
            };
        }
    }
}