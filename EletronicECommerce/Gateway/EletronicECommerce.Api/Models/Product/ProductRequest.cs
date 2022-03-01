using System;
using System.Collections.Generic;

namespace EletronicECommerce.Api.Models.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal SalePrice { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
        public Guid CategoryIdentifier { get; set; }
    }
}