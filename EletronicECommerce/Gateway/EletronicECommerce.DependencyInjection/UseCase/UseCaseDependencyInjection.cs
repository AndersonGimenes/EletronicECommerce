using EletronicECommerce.UseCase.Implementation.Builder;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection.UseCase
{
    internal static class UseCaseDependencyInjection
    {
        internal static void UseCaseDI(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserBuilder, CreateUserBuilder>();
            services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();

            services.AddTransient<ICreateCategoryBuilder, CreateCategoryBuilder>();
            services.AddTransient<IRegisterCategoryUseCase, RegisterCategoryUseCase>();

            services.AddTransient<ICreateProductBuilder, CreateProductBuilder>();
            services.AddTransient<IRegisterProductUseCase, RegisterProductUseCase>(); 

            services.AddTransient<ICreateCustomerBuilder, CreateCustomerBuilder>();
            services.AddTransient<IRegisterCustomerUseCase, RegisterCustomerUseCase>();   

            services.AddTransient<IRegisterPaymentUseCase, RegisterPaymentUseCase>();
        }
    }
}