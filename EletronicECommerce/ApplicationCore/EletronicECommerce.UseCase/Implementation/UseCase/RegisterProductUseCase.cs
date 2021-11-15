using System;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterProductUseCase : RegisterBaseUseCase<Product>, IRegisterProductUseCase
    {
        public RegisterProductUseCase(ICreateProductBuilder createProductBuilder)
            : base(createProductBuilder)
        {
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}