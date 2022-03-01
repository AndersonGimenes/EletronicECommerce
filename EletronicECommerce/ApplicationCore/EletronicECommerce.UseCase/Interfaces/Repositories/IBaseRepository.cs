using System;
using EletronicECommerce.Domain.Entities;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        T GetByIdentifier(Guid identifier, string paramName);
        T Create(T entity);
    }
}