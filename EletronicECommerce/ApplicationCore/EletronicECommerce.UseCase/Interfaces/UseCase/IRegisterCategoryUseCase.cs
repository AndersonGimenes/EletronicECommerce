using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterCategoryUseCase
    {
        IEnumerable<Category> GetAll();
        Category Create(Category category);
        void Delete(Guid identifier);
    }
}