using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.Domain.Validation;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builder
{
    public class CreateCustomerBuilder : ICreateCustomerBuilder
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private Customer _customer;

        public CreateCustomerBuilder(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
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
            new RegisterCustomerUseCaseValidation().IsValid(_customer, _customerRepository, _userRepository);

            return this;
        }
    }
}