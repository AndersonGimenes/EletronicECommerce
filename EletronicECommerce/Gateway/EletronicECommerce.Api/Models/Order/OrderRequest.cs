using System;
using System.Collections.Generic;

namespace EletronicECommerce.Api.Models.Order
{
    public class OrderRequest
    {
        public Guid UserIdentifier { get; set; }
        public IEnumerable<OrderProduct> ProductsItems { get; set; }
    }
}