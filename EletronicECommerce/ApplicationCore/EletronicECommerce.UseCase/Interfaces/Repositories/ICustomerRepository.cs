using System;
using EletronicECommerce.Domain.Entities.Store;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByDocumentNumber(string number);
        Customer GetByUserIdentifier(Guid user);
    }
}