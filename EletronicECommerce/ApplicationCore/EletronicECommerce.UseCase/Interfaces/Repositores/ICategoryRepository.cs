using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositores
{
    public interface ICategoryRepository
    {
        Category GetByName(string name);
        Category Create(Category category);
    }
}