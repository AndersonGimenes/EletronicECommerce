using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterUserUseCase : RegisterBaseUseCase<User>, IRegisterUserUseCase
    {
        public RegisterUserUseCase(ICreateUserBuilder createUserBuilder) : base(createUserBuilder)
        {
        }
    }
}