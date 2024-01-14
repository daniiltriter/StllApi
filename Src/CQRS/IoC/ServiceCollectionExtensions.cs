using System.Reflection;
using AutoMapper.Internal;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.CQRS.Abstractions;
using Stll.CQRS.Services;

namespace Stll.CQRS.Commands.IoC;

public static class ServiceCollectionExtensions
{
    public static void AddCatcher(this IServiceCollection services,  Assembly assembly)
    {
        services.AddSingleton<IBusinessExecutor, BusinessExecutor>();
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