using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Stll.Core.Configurations;
using Stll.Core.Domain;
using Stll.Core.Registrations.Abstractions;

namespace Stll.Core.Registrations.Modules;

public class DomainStartupModule : IStartupModule
{
    private readonly IOptions<ApplicationSettings> _settings;

    public DomainStartupModule(IOptions<ApplicationSettings> settings)
    {
        _settings = settings;
    }
    public void Apply(IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            var dbConnectionString = _settings.Value.Domain.Connection;

            var sqlVersion = ServerVersion.AutoDetect(dbConnectionString);
            options.UseMySql(dbConnectionString, sqlVersion);
        });
    }
}