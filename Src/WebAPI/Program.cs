using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Stll.Shared.Configurations;
using Stll.WebAPI.Helpers;
using Stll.WebAPI.Registrations;

namespace Stll.WebAPI
{
    public class Program
    {
        public static void Main()
        {
            var appSettingsPath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
            
            var configurationLoader = new ConfigurationLoader();
            var configurationLoaderResponse = configurationLoader.LoadOrCreateJson(appSettingsPath);

            var configurations = configurationLoaderResponse.Value;
            
            var webHostBuilder = new WebHostBuilder();

            webHostBuilder.UseKestrel();
            webHostBuilder.UseConfiguration(configurations);
            webHostBuilder.ConfigureAppConfiguration(b => b.AddConfiguration(configurations));
            webHostBuilder.ConfigureServices(services =>
            {
                services.AddOptions();
                services.Configure<ApplicationSettings>(configurations);
                
                var authenticationSection = configurations.GetSection(nameof(ApplicationSettings.Authentication));
                services.Configure<AuthenticationSection>(authenticationSection);
                
                var domainSection = configurations.GetSection(nameof(ApplicationSettings.Domain));
                services.Configure<DomainSection>(domainSection);
            });
            webHostBuilder.UseStartup<Startup>();

            var webHost = webHostBuilder.Build();
            webHost.Run();
        }
    }
}






