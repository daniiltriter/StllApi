using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Requests;
using Stll.CQRS.Helpers;
using Stll.WebAPI.Helpers;
using Stll.WebAPI.Registrations.Abstractions;
using Stll.Commands.Helpers;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Commands.IoC;
using Stll.CQRS.Services;

namespace Stll.WebAPI.Registrations.Modules;

public class AssembliesStartupModule : IStartupModule
{
    public void Apply(IServiceCollection services)
    {
        var assemblies = new[]
        {
            CoreAssemblyHelper.Assembly,
            CqrsAssemblyHelper.Assembly,
            CommandsAssemblyHelper.Assembly,
            RequestsAssemblyHelper.Assembly
        };
        
        services.AddMediatR(assemblies);
        services.AddAutoMapper(assemblies);
        services.AddSingleton<IExecutor, Executor>();
        //services.AddBusinessExecutor(assemblies);
    }
}