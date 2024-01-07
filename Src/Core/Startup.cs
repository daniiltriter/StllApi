using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Configurations;
using Stll.Core.Domain;

namespace Stll.Core;

public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerDocument();
        services.AddControllers();
        services.AddDbContext<ApplicationContext>(options =>
        {
            var dbConnectionName = nameof(ApplicationSettings.DbConnection);
            var dbConnectionString = _configuration.GetSection(dbConnectionName).Value;

            var sqlVersion = ServerVersion.AutoDetect(dbConnectionString);
            options.UseMySql(dbConnectionString, sqlVersion);
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(b => b.MapControllers());
        
        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}