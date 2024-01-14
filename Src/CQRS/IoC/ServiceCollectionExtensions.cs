using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stll.WebAPI.Commands.Services;

namespace Stll.WebAPI.Commands.IoC;

public static class ServiceCollectionExtensions
{
    public static void AddCatcher(this IServiceCollection services, Action<AssemblySettings> settingsModifier)
    {
        var settings = new AssemblySettings();
        settingsModifier(settings);
        
        var assemblies = settings.GetAssemblies();
        services.AddMediatR(assemblies);

        services.AddSingleton<ICatcher, MediatorCatcher>();
    }
}