namespace CustomerAPIServices
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {                    
                    config.AddJsonFile("appsettings.json");                  
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>()
                .UseUrls("http://localhost:9001")
                .Build();
    }
}
