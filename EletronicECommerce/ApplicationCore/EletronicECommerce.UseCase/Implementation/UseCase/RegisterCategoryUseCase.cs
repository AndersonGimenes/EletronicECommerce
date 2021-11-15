using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterCategoryUseCase : RegisterBaseUseCase<Category>,  IRegisterCategoryUseCase
    {
        public RegisterCategoryUseCase(ICreateCategoryBuilder createCategoryBuilder)
            : base(createCategoryBuilder)
        {
        }
    }
}