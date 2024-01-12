using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stll.WebAPI.Registrations.Abstractions;

namespace Stll.WebAPI.Registrations.Modules;

public class EndpointsStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services.AddControllers();
    }
}