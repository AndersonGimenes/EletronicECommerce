using AutoMapper;
using EletronicECommerce.DependencyInjection.Repository;
using EletronicECommerce.DependencyInjection.UseCase;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfiguration(this IServiceCollection services, Profile profile)
        {
            services.UseCaseDI();
            services.RepositoryDI();
            
            services.DataBaseDI();
            services.AutoMapperDI(profile);  
        }

        #region [ Private Methods ]
        private static void AutoMapperDI(this IServiceCollection services, Profile profile)
        {
            var cfg = new MapperConfiguration(opts =>{
                opts.AddProfile(profile);
                opts.AddProfile(new MappingProfileRepository());
            });
            services.AddSingleton(cfg.CreateMapper());         
        }

        private static void DataBaseDI(this IServiceCollection services)
        {
            services.AddDbContext<EletronicECommerceContext>(options =>
                options.UseMySQL(Settings.ConnectionString));
        }
        #endregion
    }
}