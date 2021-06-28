using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositores
{
    public interface IProductRepository
    {
        Product GetByName(string name);
        Product GetByCode(string code);
        Product Create(Product product);
    }
}