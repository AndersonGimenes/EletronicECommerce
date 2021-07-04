using System.Text;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builders
{
    public class CreateProductBuilder : ICreateProductBuilder
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private Product _product;

        public CreateProductBuilder(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public Product CallRepository()
        {
            //[TO-DO] : Call create methods by repository here 
            return _product;
        }

        public IBuilder<Product> Set(Product product)
        {
            _product = product;
            return this;
        }

        public IBuilder<Product> Validate()
        {
            new RegisterProductUseCaseValidation().IsValid(_product, _productRepository, _categoryRepository);

            return this;
        }
    }
}