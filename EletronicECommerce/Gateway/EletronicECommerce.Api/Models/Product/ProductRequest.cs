using System;

namespace EletronicECommerce.Api.Models.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public Guid Category { get; set; }
    }
}