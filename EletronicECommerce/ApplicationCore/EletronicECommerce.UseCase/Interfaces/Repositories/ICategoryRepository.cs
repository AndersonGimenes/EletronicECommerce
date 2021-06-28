using System;
using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Category GetByName(string name);
        Category GetByIdentifier(Guid identifier);
        Category Create(Category category);
    }
}