using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.Entities.Admin
{
    public class Product : EntityBase
    {
        public Product()
            : base(Guid.Empty)
        {

        }
        
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal SalePrice { get; private set; }
        public Guid CategoryIdentifier { get; private set; }
        public IEnumerable<Stock> Stocks { get; private set; }
    }
}