using Microsoft.Extensions.DependencyInjection;

namespace Stll.WebAPI.Registrations.Abstractions;

public interface IStartupModule
{
    public void Apply(IServiceCollection services);
}
