using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stll.Shared.Configurations;
using Stll.WebAPI.Registrations.Abstractions;

namespace Stll.WebAPI.Registrations.Modules;

public class AuthenticateStartupModule : IStartupModule
{
    private readonly IOptions<ApplicationSettings> _settings;

    public AuthenticateStartupModule(IOptions<ApplicationSettings> settings)
    {
        _settings = settings;
    }
    public void Apply(IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.SaveToken = true;
                
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Base64UrlTextEncoder.Decode(_settings.Value.Authentication.Key)),
                ValidateIssuerSigningKey = true,
                NameClaimType = JwtRegisteredClaimNames.Sub
            };
        });
        
        services.AddAuthorization();
    }
}