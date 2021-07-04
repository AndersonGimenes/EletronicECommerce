using System;
using EletronicECommerce.Domain.Entities;

namespace EletronicECommerce.UseCase.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        T GetByName(string name);
        T GetByIdentifier(Guid identifier);
        T Create(T entity);
    }
}