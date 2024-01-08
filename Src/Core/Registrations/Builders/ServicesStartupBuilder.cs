using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Builders;

public class StartupServicesBuilder
{
    private readonly IServiceCollection _services;
    private List<IStartupModule> _modules = new();

    public StartupServicesBuilder(ref IServiceCollection services)
    {
        _services = services;
    }
    
    public void ApplyModule(IStartupModule module)
    {
        _modules.Add(module);
        module.Apply(_services);
    }
}
