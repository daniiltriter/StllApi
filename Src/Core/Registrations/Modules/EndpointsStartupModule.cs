using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

public class EndpointsStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services.AddControllers();
    }
}