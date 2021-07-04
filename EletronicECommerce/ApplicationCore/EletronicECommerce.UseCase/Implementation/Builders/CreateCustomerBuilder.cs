using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.Domain.Validation;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builders
{
    public class CreateCustomerBuilder : ICreateCustomerBuilder
    {
        private readonly ICustomerRepository _customerRepository;
        private Customer _customer;

        public CreateCustomerBuilder(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer CallRepository()
        {
            //[TO-DO] : Call create methods by repository here 
            return _customer;
        }

        public IBuilder<Customer> Set(Customer customer)
        {
            _customer = customer;
            return this;
        }

        public IBuilder<Customer> Validate()
        {
            _customer.IsValid();
            new RegisterCustomerUseCaseValidation().IsValid(_customer, _customerRepository);

            return this;
        }
    }
}