using AutoMapper;
using EletronicECommerce.Api.Mapping;
using EletronicECommerce.Repository;
using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.Api.DependencyInjection
{
    public class ConfigureDependencyInjection
    {
        private readonly IServiceCollection _services;

        public ConfigureDependencyInjection(IServiceCollection services)
        {
            _services = services;

            UseCaseDI();
            AutomapperDI();
            RepositoryDI();
        }

        private void AutomapperDI()
        {
            var cfg = new MapperConfiguration(opts =>{
                opts.AddProfile(new MappingProfileApi());
            });
            _services.AddSingleton(cfg.CreateMapper());         
        }

        private void UseCaseDI()
        {
            _services.AddTransient<ICreateUserBuilder, CreateUserBuilder>();
            _services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private void RepositoryDI()
        {
            _services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}