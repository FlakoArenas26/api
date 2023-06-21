using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MiDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SCAConnection"));
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuración de la aplicación
        }
    }
}
