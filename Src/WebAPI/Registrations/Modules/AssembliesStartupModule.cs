using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.Commands.Helpers;
using Stll.WebAPI.Helpers;
using Stll.WebAPI.Registrations.Abstractions;

namespace Stll.WebAPI.Registrations.Modules;

public class AssembliesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        var assemblies = new[]
        {
            CoreAssemblyHelper.Assembly,
            CqrsAssemblyHelper.Assembly
        };
        
        services.AddMediatR(assemblies);
        services.AddAutoMapper(assemblies);
    }
}