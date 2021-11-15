using System;
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
        public Guid Category { get; private set; }
        public Stock Stock { get; private set; }
    }
}