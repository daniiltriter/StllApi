using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stll.Shared.Configurations;
using Stll.Shared.Types;

namespace Stll.Shared.Services;

public class JwtTokenBuilder : IJwtTokenBuilder
{
    private readonly IOptions<AuthenticationSection> _settings;

    public JwtTokenBuilder(IOptions<AuthenticationSection> settings)
    {
        _settings = settings;
    }
    
    public string Build(JwtData data)
    {
        var subject = data.Subject;
        
        var decodedKey = Base64UrlTextEncoder.Decode(_settings.Value.Key);
        var securityKey = new SymmetricSecurityKey(decodedKey);
        
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = DateTime.UtcNow.AddHours(_settings.Value.LifetimeHours),
            //Issuer = _settings.Value.Issuer,
            SigningCredentials = signingCredentials
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
