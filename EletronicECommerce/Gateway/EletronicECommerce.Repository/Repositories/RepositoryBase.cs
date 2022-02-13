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
            
            _context.Add(model);

            model.SetCreateDate();

            this.SaveChanges();

            return entity;
        }

        public void Create(TModel model, Action action)
        {
            if(action != null)
                action.Invoke();
                
            this.Create(model);
        }

        public void Create(TModel model)
        {
            _context.Add(model);

            model.SetCreateDate();            
        }

        public void SaveChanges() => _context.SaveChanges();


        public TEntity GetByIdentifier(Guid identifier, string paramName)
        {   
            var users = _context.GetType().GetProperty(paramName).GetValue(_context) as DbSet<TModel>; 

            return _mapper.Map<TEntity>(users.FirstOrDefault(x => x.Id == identifier));
        }
        
    }
}