using Microsoft.Extensions.DependencyInjection;

namespace Stll.Core.Registrations.Abstractions;

public interface IStartupModule
{
    public void Apply(IServiceCollection services);
}
