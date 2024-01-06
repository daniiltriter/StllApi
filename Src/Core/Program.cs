using Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var webHost = new WebHostBuilder()
    .UseKestrel()
    .ConfigureServices(services =>
    {
        services.AddOptions();
    })
    .UseStartup<Startup>()
    .UseUrls()
    .Build();
    
webHost.Run();