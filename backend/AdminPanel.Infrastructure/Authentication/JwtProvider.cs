using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AdminPanel.Application.Abstractions.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdminPanel.Infrastructure.Authentication;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly SymmetricSecurityKey _key = 
        new (Encoding.UTF8.GetBytes(options.Value.AccessTokenSettings.Key));
    
    public string GenerateAccessToken(Guid accountId)
    {
        List<Claim> claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, accountId.ToString()),
        };
        
        var token = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256),
            expires: DateTime.UtcNow.AddMinutes(options.Value.AccessTokenSettings.LifeTimeInMinutes),
            audience: options.Value.AccessTokenSettings.Audience,
            issuer: options.Value.AccessTokenSettings.Issuer,
            claims: claims
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }

    public string GenerateRefreshToken()
    {
        var size = options.Value.RefreshTokenSettings.Length;
        var buffer = new byte[size];
        RandomNumberGenerator.Fill(buffer);
        return Convert.ToBase64String(buffer);
    }

    public int GetRefreshTokenLifetimeInMinutes()
    {
        return options.Value.RefreshTokenSettings.LifeTimeInMinutes;
    }

    public Guid? GetAccountIdByToken(string token)
    {
        try
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = options.Value.AccessTokenSettings.Issuer,
                ValidAudience = options.Value.AccessTokenSettings.Audience,
                IssuerSigningKey = _key,
                ClockSkew = TimeSpan.FromMinutes(0)
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            var claims = jwtHandler.ValidateToken(token, tokenValidationParameters, out _);
            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);

            return userId;
        }
        catch 
        {
            return null;
        }
    }
}