using EletronicECommerce.Domain.Entities.Store;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterCustomerUseCase :IRegisterBaseUseCase<Customer>
    {
        void Update(Customer customer);
    }
}