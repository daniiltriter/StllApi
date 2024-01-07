using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Stll.Core
{
    public class Program
    {
        public static void Main()
        {
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
        }
    }
}

