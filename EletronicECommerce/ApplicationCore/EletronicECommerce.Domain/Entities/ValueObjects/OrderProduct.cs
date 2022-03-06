using System;

namespace EletronicECommerce.Domain.Entities.ValeuObjects
{
    public class OrderProduct
    {
        public Guid OrderIdentifier { get; private set; }
        public Guid ProductIdentifier { get; private set; }
        public int Quantity { get; private set; }

        public OrderProduct SetOrder(Guid order)
        {
            OrderIdentifier = order;
            return this;
        }
    }
}
