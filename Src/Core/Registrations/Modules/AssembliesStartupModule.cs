using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        };
        
        var mapperAssemblies = new[]
        {
            DomainAssemblyHelper.Assembly,
            TypesAssemblyHelper.Assembly,
        };
        
        services.AddMediatR(mediatorAssemblies);
        services.AddAutoMapper(mapperAssemblies);
    }
}