using System;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Product : EntityBase
    {
        public Product(string name, string code, decimal purchasePrice, decimal salePrice, int quantity, Guid category, Guid guid)
            : base(guid)
        {
            Name = name;
            Code = code;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Quantity = quantity;
            Category = category;
        }

        public string Name { get; }
        public string Code { get; }
        public decimal PurchasePrice { get; }
        public decimal SalePrice { get; }
        public int Quantity { get; }
        public Guid Category { get; }
    }
}