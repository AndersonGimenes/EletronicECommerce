using EletronicECommerce.Repository;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection.Repository
{
    internal class RepositoryDependencyInjection
    {
        public RepositoryDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}