using EletronicECommerce.Domain.Entities;

namespace EletronicECommerce.UseCase.Interfaces.Builder
{
    public interface IBuilder<T> where T : EntityBase
    {
        IBuilder<T> Set(T entity);
        IBuilder<T> Validate();
        T CallRepository();
    }
}