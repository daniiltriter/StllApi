using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stll.Core.Helpers;

namespace Stll.Core
{
    public class Program
    {
        public static void Main()
        {
            var appSettingsPath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
            
            var configurationLoader = new ConfigurationLoader();
            var loaderResponse = configurationLoader.LoadOrCreateJson(appSettingsPath);
            
            var webHostBuilder = new WebHostBuilder();
            
            webHostBuilder.UseKestrel();
            webHostBuilder.UseConfiguration(loaderResponse.Value);
            webHostBuilder.ConfigureAppConfiguration(b => b.AddConfiguration(loaderResponse.Value));
            webHostBuilder.ConfigureServices(services => services.AddOptions());
            webHostBuilder.UseStartup<Startup>();
            
            var webHost = webHostBuilder.Build();
    
            webHost.Run();
        }
    }
}

