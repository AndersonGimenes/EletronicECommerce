using System;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Product : EntityBase
    {
        // Constructor used for automapper
        // TODO : Refactor for update
        public Product()
            : base(Guid.Empty)
        {
            
        }

        // Constructor used for testing
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

        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Quantity { get; private set; }
        public Guid Category { get; private set; }
    }
}