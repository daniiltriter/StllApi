using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;
using Stll.Core.Services;

namespace Stll.Core.Registrations.Modules;

public class ServicesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenBuilder, JwtTokenBuilder>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
    }
}