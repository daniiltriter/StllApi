using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

public class EndpointsStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddControllers();
    }
}