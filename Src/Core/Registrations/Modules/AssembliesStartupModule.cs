using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.Commands.Helpers;
using Stll.Core.Helpers;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

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