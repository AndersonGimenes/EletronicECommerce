using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities;

namespace EletronicECommerce.UseCase.Interfaces.UseCase
{
    public interface IRegisterBaseUseCase<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        void Delete(Guid identifier);
    }
}