using System;
using System.Collections.Generic;

namespace EletronicECommerce.Api.Models.Order
{
    public class OrderResponse
    {
        public Guid Identifier { get; set; }
        public Guid User { get; set; }
        public IEnumerable<Guid> Products { get; set; }
        public string StatusOrder{get; set;}
        public string TypePayment { get; set; }
    }
}