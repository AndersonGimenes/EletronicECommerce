using System.Text;
using AutoMapper;
using EletronicECommerce.Api.Mapping;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Repository;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace EletronicECommerce.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication(opts => 
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SecurityTokenKey)),
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false, 
                    ValidIssuer = Settings.Issuer                
                };
            }); 

            #region [ Use Case ]            
            services.AddTransient<ICreateUserBuilder, CreateUserBuilder>();
            services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();
            #endregion

            #region [ Repository ]
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion


            var cfg = new MapperConfiguration(opts =>{
                opts.AddProfile(new MappingProfileApi());
            });
            services.AddSingleton(cfg.CreateMapper());         
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
