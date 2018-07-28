namespace APIGateway
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Ocelot.DependencyInjection;
    using Ocelot.Middleware;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.UseStartup<Startup>()
                   .UseUrls("http://*:9000")
                   .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("configuration.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s =>
               {
                   s.AddOcelot();
                   s.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
               })
                .Configure(a =>
                {                    
                    a.UseOcelot().Wait();
                });

        // public static void Main(string[] args)
        // {
        //     IWebHostBuilder builder = new WebHostBuilder();
        //     builder.ConfigureServices(s =>
        //     {
        //         s.AddSingleton(builder);
        //     });
        //     builder.UseKestrel()
        //            .UseContentRoot(Directory.GetCurrentDirectory())
        //            .UseStartup<Startup>()
        //            .UseUrls("http://localhost:9000");

        //     var host = builder.Build();
        //     host.Run();
        // }
    }
}
