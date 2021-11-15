using System.Text;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterProductUseCaseValidation
    {
        internal static void Validate(Product product, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            var stringBuilder = new StringBuilder();
            
            var productDto = productRepository.GetByName(product.Name);
            var categoryDto = categoryRepository.GetByIdentifier(product.Category, "Categories");            
            
            if(productDto != null)
                stringBuilder.Append($"The {product.Name} product name already exists.");

            productDto = productRepository.GetByCode(product.Code);

            if(productDto != null)
                stringBuilder.Append($"The {product.Code} product code already exists.");

            if(categoryDto is null)
                stringBuilder.Append($"Please select any valid category.");

            if(stringBuilder.Length > 0)
                throw new UseCaseException(stringBuilder.ToString());
        }
    }
}