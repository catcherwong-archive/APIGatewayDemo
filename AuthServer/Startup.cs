namespace AuthServer
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.Configure<Controllers.Audience>(Configuration.GetSection("Audience"));
        }

        public void Configure(IApplicationBuilder app)
        {            
            app.UseMvc();
        }
    }
}
