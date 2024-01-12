using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stll.Domain.Abstractions;
using Stll.Domain.Configurations;
using Stll.Domain.Services;

namespace Stll.Domain.IoC;

public static class ServiceCollectionExtensions
{
    public static DomainServiceBuilder<TContext> AddDomainContext<TContext>(this IServiceCollection services, 
        Action<DomainSettings> settingsModifier) 
        where TContext : DbContext
    {
        var settings = new DomainSettings();
        settingsModifier(settings);

        services.AddSingleton<IDomainService, DomainService>();
        
        services.AddDbContext<TContext>(options =>
        {
            var dbConnectionString = settings.ConnectionString;

            var sqlVersion = ServerVersion.AutoDetect(dbConnectionString);
            options.UseMySql(dbConnectionString, sqlVersion);
        });
        
        return DomainServiceBuilder<TContext>.Initialize(services);
    }
}