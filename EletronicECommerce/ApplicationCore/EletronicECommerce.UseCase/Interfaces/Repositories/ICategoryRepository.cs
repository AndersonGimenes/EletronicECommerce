using System;
using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetByName(string name);
    }
}