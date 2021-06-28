using System.Text;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositores;

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
            var stringBuilder = new StringBuilder();
            
            var product = _productRepository.GetByName(_product.Name);
            var category = _categoryRepository.GetByIdentifier(_product.Category);            
            
            if(product != null)
                stringBuilder.Append($"The {_product.Name} product name already exists.");

            product = _productRepository.GetByCode(_product.Code);

            if(product != null)
                stringBuilder.Append($"The {_product.Code} product code already exists.");

            if(category is null)
                stringBuilder.Append($"Please select any valid category.");

            if(stringBuilder.Length > 0)
                throw new UseCaseException(stringBuilder.ToString());

            return this;
        }
    }
}