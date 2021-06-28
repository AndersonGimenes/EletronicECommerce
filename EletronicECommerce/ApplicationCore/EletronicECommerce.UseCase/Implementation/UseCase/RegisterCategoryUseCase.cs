using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.Builder;
using EletronicECommerce.UseCase.Interfaces.UseCase;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public class RegisterCategoryUseCase : IRegisterCategoryUseCase
    {
        private readonly ICreateCategoryBuilder _categoryBuilder;

        public RegisterCategoryUseCase(ICreateCategoryBuilder categoryBuilder)
        {
            _categoryBuilder = categoryBuilder;
        }
        public Category Create(Category category) =>
                        _categoryBuilder
                            .Set(category)
                            .Validate()
                            .CallRepository();

        public void Delete(Guid identifier)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}