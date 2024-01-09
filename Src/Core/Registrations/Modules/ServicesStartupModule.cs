using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;
using Stll.Shared.Services;

namespace Stll.Core.Registrations.Modules;

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