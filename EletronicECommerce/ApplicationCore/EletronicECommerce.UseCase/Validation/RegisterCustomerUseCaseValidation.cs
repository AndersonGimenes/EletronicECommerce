using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal class RegisterCustomerUseCaseValidation
    {
        internal void IsValid(Customer customer, ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            var userCustomer = customerRepository.GetByUserIdentifier(customer.User);

            if(userCustomer != null)
                throw new UseCaseException($"There is already a record linked to this user.");

            var user = userRepository.GetByIdentifier(customer.User);

            if(user is null)
                throw new UseCaseException($"Must enter a valid user.");

            var customerDto = customerRepository.GetByDocumentNumber(customer.Document.Number);

            if(customerDto != null)
                throw new UseCaseException($"This document number {customer.Document.Number} is registered.");

        }
    }
}