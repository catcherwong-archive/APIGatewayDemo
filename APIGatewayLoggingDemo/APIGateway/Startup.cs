// namespace APIGateway
// {    
//     using Microsoft.AspNetCore.Builder;
//     using Microsoft.AspNetCore.Hosting;
//     using Microsoft.Extensions.Configuration;
//     using Microsoft.Extensions.DependencyInjection;
//     using Microsoft.Extensions.Logging;
//     using NLog.Extensions.Logging;
//     using Ocelot.DependencyInjection;
//     using Ocelot.Middleware;

//     public class Startup
//     {
//         public Startup(IHostingEnvironment env)
//         {
//             var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
//             builder.SetBasePath(env.ContentRootPath)
//                    .AddJsonFile("appsettings.json")
//                    //add configuration.json
//                    .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
//                    .AddEnvironmentVariables();

//             Configuration = builder.Build();
//         }

//         public IConfigurationRoot Configuration { get; }
        
//         public void ConfigureServices(IServiceCollection services)
//         {            

//             services.AddOcelot(Configuration);
//         }

//         public void Configure(IApplicationBuilder app ,ILoggerFactory loggerFactory)
//         {
//             //console logging
//             loggerFactory.AddConsole(Configuration.GetSection("Logging"));

//             //nlog logging
//             loggerFactory.AddNLog();
//             loggerFactory.ConfigureNLog("nlog.config");

//             app.UseOcelot().Wait();
//         }
//     }
// }
