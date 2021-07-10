using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using EletronicECommerce.UseCase.Validation;

namespace EletronicECommerce.UseCase.Implementation.Builder
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
            new RegisterCategoryUseCaseValidation().IsValid(_category, _categoryRepository);         

            return this;
        }

    }
}