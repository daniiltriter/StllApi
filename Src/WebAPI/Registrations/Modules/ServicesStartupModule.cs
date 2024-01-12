using Microsoft.Extensions.DependencyInjection;
using Stll.Shared.Services;
using Stll.WebAPI.Registrations.Abstractions;
using Stll.WebAPI.Services;

namespace Stll.WebAPI.Registrations.Modules;

public class ServicesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        services.AddSingleton<IJwtTokenBuilder, JwtTokenBuilder>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IFileService, FileService>();
    }
}