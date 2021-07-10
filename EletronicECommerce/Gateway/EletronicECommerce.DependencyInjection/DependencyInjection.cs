using AutoMapper;
using EletronicECommerce.DependencyInjection.Repository;
using EletronicECommerce.DependencyInjection.UseCase;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _services;

        public DependencyInjection(IServiceCollection services, Profile profile)
        {
            _services = services;

            new UseCaseDependencyInjection(services);
            new RepositoryDependencyInjection(services);

            DataBaseDI();
            AutoMapperDI(profile);            
        }

        private void AutoMapperDI(Profile profile)
        {
            var cfg = new MapperConfiguration(opts =>{
                opts.AddProfile(profile);
            });
            _services.AddSingleton(cfg.CreateMapper());         
        }

        private void DataBaseDI()
        {
            _services.AddDbContext<EletronicECommerceContext>(options =>
                options.UseMySQL(Settings.ConnectionString));
        }
    }
}