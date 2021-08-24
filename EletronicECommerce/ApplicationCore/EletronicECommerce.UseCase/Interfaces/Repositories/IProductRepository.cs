using EletronicECommerce.Domain.Entities.Admin;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByCode(string code);
    }
}