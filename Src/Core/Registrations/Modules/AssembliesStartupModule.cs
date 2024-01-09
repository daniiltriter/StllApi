using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.Commands.Helpers;
using Stll.Core.Helpers;
using Stll.Core.Registrations.Abstractions;
using Stll.Domain.Helpers;
using Stll.Types.Assemblies;

namespace Stll.Core.Registrations.Modules;

public class AssembliesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        var mediatorAssemblies = new[]
        {
            CoreAssemblyHelper.Assembly,
            CqrsAssemblyHelper.Assembly
        };
        
        var mapperAssemblies = new[]
        {
            CqrsAssemblyHelper.Assembly,
            CoreAssemblyHelper.Assembly,
            DomainAssemblyHelper.Assembly,
            TypesAssemblyHelper.Assembly,
        };
        
        services.AddMediatR(mediatorAssemblies);
        services.AddAutoMapper(mapperAssemblies);
    }
}