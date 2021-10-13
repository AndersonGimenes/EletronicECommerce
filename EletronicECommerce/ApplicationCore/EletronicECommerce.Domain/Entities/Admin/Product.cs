using System;
using EletronicECommerce.Domain.Entities.ValeuObjects;

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
        public Product(string name, string code, decimal salePrice, Guid category, Stock stock, Guid guid)
            : base(guid)
        {
            Name = name;
            Code = code;
            SalePrice = salePrice;
            Category = category;
            Stock = stock;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal SalePrice { get; private set; }
        public Guid Category { get; private set; }
        public Stock Stock { get; private set; }
    }
}