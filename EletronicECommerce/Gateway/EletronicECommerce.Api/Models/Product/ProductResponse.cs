using System;

namespace EletronicECommerce.Api.Models.Product
{
    public class ProductResponse
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal SalePrice { get; set; }
        public Stock Stock { get; set; }
        public Guid Category { get; set; }
    }
}