using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterProductUseCase
    {
        IEnumerable<Product> GetAll();
        Product Create(Product product);
        void Delete(Guid identifier);
        void Update(Product product);

    }
}