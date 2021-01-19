namespace APIGateway
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Ocelot.DependencyInjection;
    using Ocelot.Middleware;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.UseStartup<Startup>()
                   .UseUrls("https://*:44338")
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
                   s.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
               })
                .Configure(a =>
                {                    
                    a.UseOcelot().Wait();
                });

        public static IHostBuilder CreateHostBuilder(string[] args) =>

           Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hosting, config) =>
           {
               config.AddJsonFile("configuration.json");

           }).ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
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
