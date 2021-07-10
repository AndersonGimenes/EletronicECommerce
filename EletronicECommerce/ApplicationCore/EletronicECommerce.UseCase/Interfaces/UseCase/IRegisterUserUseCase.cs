using EletronicECommerce.Domain.Entities.Shared;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterUserUseCase : IRegisterBaseUseCase<User>
    {
        User CheckUser(User user);
    }
}