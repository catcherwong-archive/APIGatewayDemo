using System;
namespace APIGateway
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;
    using Ocelot.DependencyInjection;
    using Ocelot.Middleware;
    using Swashbuckle.AspNetCore.Swagger;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseUrls("http://*:9000")
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("ocelot.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s =>
               {
                   s.AddOcelot();
                   s.AddMvc();
                    s.AddSwaggerGen(c =>
                   {
                       c.SwaggerDoc("v1", new Info { Title = "GW", Version = "v1" });
                       var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                       var xmlPath = Path.Combine(basePath, "APIGateway.xml");
                       c.IncludeXmlComments(xmlPath);
                   });
               })
                .Configure(a =>
                {
                    a.UseMvc().UseSwagger().UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/a/swagger.json", "APIServiceA");
                        c.SwaggerEndpoint("/b/swagger.json", "APIServiceB");
                    });

                    a.UseOcelot().Wait();
                })
                .Build();
    }
}
