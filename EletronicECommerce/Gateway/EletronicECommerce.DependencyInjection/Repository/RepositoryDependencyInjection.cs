using EletronicECommerce.Repository.Repositories;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection.Repository
{
    internal static class RepositoryDependencyInjection
    {
        internal static void RepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}