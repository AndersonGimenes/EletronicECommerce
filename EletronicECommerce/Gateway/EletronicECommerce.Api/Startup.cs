using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EletronicECommerce.Api
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            config.SetValues();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Authentication();

            services.SwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
