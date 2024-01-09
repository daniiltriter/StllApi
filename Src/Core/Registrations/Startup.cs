using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Stll.Core.Registrations.Builders;
using Stll.Core.Registrations.Modules;
using Stll.Shared.Configurations;

namespace Stll.Core.Registrations;

public class Startup
{
    private readonly IOptions<ApplicationSettings> _configuration;
    
    public Startup(IOptions<ApplicationSettings> configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var servicesBuilder = new StartupServicesBuilder(ref services);

        if (System.Diagnostics.Debugger.IsAttached)
        {
            servicesBuilder.ApplyModule(new SwaggerStartupModule());
        }
        servicesBuilder.ApplyModule(new ServicesStartupModule());
        servicesBuilder.ApplyModule(new AuthenticateStartupModule(_configuration));
        servicesBuilder.ApplyModule(new DomainStartupModule(_configuration));
        servicesBuilder.ApplyModule(new EndpointsStartupModule());
        servicesBuilder.ApplyModule(new AssembliesStartupModule());

        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(b => b.MapControllers());


        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}