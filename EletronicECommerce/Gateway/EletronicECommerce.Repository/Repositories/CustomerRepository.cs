using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.Repository.Models.SubModels;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, CustomerModel>, ICustomerRepository
    {
        private readonly IMapper _mapper;
        private readonly EletronicECommerceContext _context;
        public CustomerRepository(EletronicECommerceContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public override Customer Create(Customer customer)
        {       
            var model = _mapper.Map<CustomerModel>(customer).CompleteMapper();
           
            base.Create(model, () => 
                _context.Addresses.AddRange(new AddressModel[]{model.BillingAddress, model.DeliveryAddess})
            );

            base.SaveChanges();
            
            return customer;
        }


        public Customer GetByDocumentNumber(string number) => _mapper.Map<Customer>(_context.Customers.FirstOrDefault(x => x.DocumentNumber == number));
        
        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Customer GetByUserIdentifier(Guid user) => _mapper.Map<Customer>(_context.Customers.FirstOrDefault(x => x.Id == user));
    }
}