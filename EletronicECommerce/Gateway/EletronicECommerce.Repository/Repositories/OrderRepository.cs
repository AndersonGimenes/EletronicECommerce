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
    }
}