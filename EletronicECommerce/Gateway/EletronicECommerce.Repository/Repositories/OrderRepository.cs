using AutoMapper;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<Order, OrderModel>, IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(EletronicECommerceContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _mapper = mapper;
        }

        public override Order Create(Order order)
        {
            var model = _mapper.Map<OrderModel>(order);

            foreach(var product in model.Products)
            {
                model.SetProductId(product);

               base.Create(model);
            }
            
            base.SaveChanges();

            return _mapper.Map<Order>(model);
        }

        public Order GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}