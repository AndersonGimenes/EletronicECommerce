using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Validation
{
    internal static class RegisterCategoryUseCaseValidation
    {
        internal static void Validate(Category category, ICategoryRepository categoryRepository)
        {
            var categoryDto = categoryRepository.GetByName(category.Name);
            
            if(categoryDto != null)
                throw new UseCaseException($"The {category.Name} category name already exists.");
        }
    }
}