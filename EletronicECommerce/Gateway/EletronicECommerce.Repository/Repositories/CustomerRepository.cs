using System;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, CostumerModel>, ICustomerRepository
    {
        public CustomerRepository(EletronicECommerceContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public Customer GetByDocumentNumber(string number)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Customer GetByUserIdentifier(Guid user)
        {
            throw new NotImplementedException();
        }
    }
}