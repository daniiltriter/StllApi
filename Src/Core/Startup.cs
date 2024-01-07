using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Stll.Core;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerDocument();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(b => b.MapControllers());
        
        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}