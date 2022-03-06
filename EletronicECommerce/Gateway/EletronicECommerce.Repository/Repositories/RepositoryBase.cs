using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EletronicECommerce.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TModel> where TEntity : EntityBase where TModel : BaseModel
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        protected RepositoryBase(EletronicECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual TEntity Create(TEntity entity)
        {       
            var model = _mapper.Map<TModel>(entity);

            Create(model);

            return entity;
        }

        public void Create(TModel model, Action action)
        {
            if(action != null)
                action.Invoke();
                
            Create(model);
        }

        public TEntity GetByIdentifier(Guid identifier, string paramName)
        {   
            var users = _context.GetType().GetProperty(paramName).GetValue(_context) as DbSet<TModel>; 

            return _mapper.Map<TEntity>(users.AsNoTracking().FirstOrDefault(x => x.Id == identifier));
        }

        private void Create(TModel model)
        {
            _context.Add(model);

            model.SetCreateDate();

            _context.SaveChanges();
        }

    }
}