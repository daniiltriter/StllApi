using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.CQRS.Helpers;
using Stll.WebAPI.Helpers;
using Stll.WebAPI.Registrations.Abstractions;
using Stll.Commands.Helpers;

namespace Stll.WebAPI.Registrations.Modules;

public class AssembliesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        var assemblies = new[]
        {
            CoreAssemblyHelper.Assembly,
            CqrsAssemblyHelper.Assembly,
            CommandsAssemblyHelper.Assembly
        };
        
        services.AddMediatR(assemblies);
        services.AddAutoMapper(assemblies);
    }
}