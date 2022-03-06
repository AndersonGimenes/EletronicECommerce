using System;
using System.Collections.Generic;

namespace EletronicECommerce.Api.Models.Order
{
    public class OrderResponse
    {
        public Guid Identifier { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserIdentifier { get; set; }
        public IEnumerable<OrderProduct> ProductsItems { get; set; }
    }
}