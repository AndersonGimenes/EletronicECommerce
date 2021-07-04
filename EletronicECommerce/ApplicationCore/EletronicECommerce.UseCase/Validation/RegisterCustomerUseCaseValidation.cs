using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal class RegisterCustomerUseCaseValidation
    {
        internal void IsValid(Customer customer, ICustomerRepository customerRepository)
        {
            var customerDto = customerRepository.GetByDocumentNumber(customer.Document.Number);

            if(customerDto != null)
                throw new UseCaseException($"This document number {customer.Document.Number} is registered.");
        }
    }
}