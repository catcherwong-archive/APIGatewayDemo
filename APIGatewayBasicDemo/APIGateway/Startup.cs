// namespace APIGateway
// {
//     using CacheManager.Core;
//     using Microsoft.AspNetCore.Builder;
//     using Microsoft.AspNetCore.Hosting;
//     using Microsoft.Extensions.Configuration;
//     using Microsoft.Extensions.DependencyInjection;
//     using Microsoft.Extensions.Logging;
//     using Ocelot.DependencyInjection;
//     using Ocelot.Middleware;
//     using System;
    
//     public class Startup
//     {
//         public Startup(IHostingEnvironment env)
//         {
//             var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
//             builder.SetBasePath(env.ContentRootPath)    
//                    //add configuration.json
//                    .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
//                    .AddEnvironmentVariables();

//             Configuration = builder.Build();
//         }

//         //change
//         public IConfigurationRoot Configuration { get; }

//         public void ConfigureServices(IServiceCollection services)
//         {
//             Action<ConfigurationBuilderCachePart> settings = (x) =>
//             {
//                 x.WithMicrosoftLogging(log =>
//                 {
//                     log.AddConsole(LogLevel.Debug);

//                 }).WithDictionaryHandle();
//             };
//             services.AddOcelot(Configuration, settings);
//         }

//         public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
//         {
//             await app.UseOcelot();
//         }
//     }
// }
