using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Product GetByIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}