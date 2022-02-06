using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByCode(string code);
        IEnumerable<Product> GetProductsByIds(IEnumerable<Guid> guids);
    }
}