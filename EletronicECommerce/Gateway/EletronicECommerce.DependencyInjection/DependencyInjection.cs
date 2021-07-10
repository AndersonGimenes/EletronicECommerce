using AutoMapper;
using EletronicECommerce.DependencyInjection.Repository;
using EletronicECommerce.DependencyInjection.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection
{
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services, Profile profile)
        {
            new UseCaseDependencyInjection(services);
            new RepositoryDependencyInjection(services);

            AutomapperDI(profile, services);
        }

        private void AutomapperDI(Profile profile, IServiceCollection services)
        {
            var cfg = new MapperConfiguration(opts =>{
                opts.AddProfile(profile);
            });
            services.AddSingleton(cfg.CreateMapper());         
        }
    }
}