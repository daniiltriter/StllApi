using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

public class AssembliesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        services.AddMediatR(typeof(Startup));
        services.AddAutoMapper(typeof(Startup));
    }
}