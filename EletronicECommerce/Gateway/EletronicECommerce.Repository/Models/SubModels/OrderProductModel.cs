using System;

namespace EletronicECommerce.Repository.Models.SubModels
{
    public class OrderProductModel
    {
        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public ProductModel Product { get; private set; }
        public OrderModel Order { get; private set; }
    }
}