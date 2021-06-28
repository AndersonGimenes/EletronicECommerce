using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Product GetByName(string name);
        Product GetByCode(string code);
        Product Create(Product product);
    }
}