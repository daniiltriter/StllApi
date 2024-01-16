using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Services;

namespace Stll.CQRS.Commands.IoC;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessExecutor(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddSingleton<IBusinessExecutor, BusinessExecutor>();
        foreach (var assembly in assemblies)
        {
            services.RegisterCandidates(assembly);
        }
    }

    private static void RegisterCandidates(this IServiceCollection services, Assembly assembly)
    {
        var assemblyTypes = assembly.GetTypes();
        foreach (var registerCandidate in assemblyTypes)
        {
            var interfaces = registerCandidate.GetInterfaces();
            if (!interfaces.Any())
            {
                continue;
            }
            
            var handlerInterface = interfaces.FirstOrDefault(IsHandler);
            if (handlerInterface is null)
            {
                continue;
            }

            services.AddSingleton(handlerInterface, registerCandidate);
        }
    }
    
    private static bool IsHandler(Type @interface)
    {
        var generics = @interface.GetGenericArguments();
        if (!generics.Any())
        {
            return false;
        }
        var handlerType = typeof(ICatcherHandler<,>).MakeGenericType(generics);
        return @interface == handlerType;
    }
}