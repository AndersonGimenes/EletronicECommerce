using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.UseCase.Implementation.Builders
{
    public class CreateCategoryBuilder : ICreateCategoryBuilder
    {
        private Category _category;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryBuilder(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CallRepository() 
        {
            //[TO-DO] : Call create methods by repository here 
            return _category;
        }            
        
        public IBuilder<Category> Set(Category category)
        {
            _category = category;
            return this;
        }

        public IBuilder<Category> Validate()
        {
            var category = _categoryRepository.GetByName(_category.Name);
            
            if(category != null)
                throw new UseCaseException($"The {_category.Name} category name already exists.");

            return this;
        }

    }
}