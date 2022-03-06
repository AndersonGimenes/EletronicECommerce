using System;

namespace EletronicECommerce.Api.Models.Order
{
    public class OrderProduct
    {
        public Guid ProductIdentifier { get; set; }
        public int Quantity { get; set; }
    }
}
