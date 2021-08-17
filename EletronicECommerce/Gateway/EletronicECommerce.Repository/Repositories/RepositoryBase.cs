using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;

namespace EletronicECommerce.Repository.Repositories
{
    public abstract class RepositoryBase<T> where T : BaseModel
    {
        private readonly EletronicECommerceContext _context;

        public RepositoryBase(EletronicECommerceContext context)
        {
            _context = context;
        }

        internal T Create(T entity)
        {
            entity.SetCreateDate();
            _context.SaveChanges();

            return entity;
        }
        
    }
}