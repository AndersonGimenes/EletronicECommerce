using AutoMapper;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using System;
using System.Linq;

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

        public Customer GetByDocumentNumber(string number) => _mapper.Map<Customer>(_context.Customers.FirstOrDefault(x => x.DocumentNumber == number));
        
        public Customer GetByUserIdentifier(Guid user) => _mapper.Map<Customer>(_context.Customers.FirstOrDefault(x => x.Id == user));
    }
}