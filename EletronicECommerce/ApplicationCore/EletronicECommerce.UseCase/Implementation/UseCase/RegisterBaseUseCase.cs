using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities;
using EletronicECommerce.UseCase.Interfaces.Builder;

namespace EletronicECommerce.UseCase.Implementation.UseCase
{
    public abstract class RegisterBaseUseCase<T> where T : EntityBase
    {
        private readonly IBuilder<T> _builder;

        public RegisterBaseUseCase(IBuilder<T> builder) 
        {
            _builder = builder;
        }
        public T Create(T entity)
        {
            var entityReady = _builder
                                .Set(entity)
                                .Validate()
                                .CallRepository();

            return entityReady;
        }

        public void Delete(Guid identifier)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }
        
    }
    
}