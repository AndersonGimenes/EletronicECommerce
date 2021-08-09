using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection.UseCase
{
    public class UseCaseDependencyInjection
    {
        public UseCaseDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<ICreateUserBuilder, CreateUserBuilder>();
            services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();

            services.AddTransient<ICreateCategoryBuilder, CreateCategoryBuilder>();
            services.AddTransient<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        }
    }
}