using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterProductUseCase : IRegisterBaseUseCase<Product>
    {
        void Update(Product product);
    }
}