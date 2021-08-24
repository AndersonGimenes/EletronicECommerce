using System;

namespace EletronicECommerce.Repository.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Quantity { get; private set; }
        public Guid Category { get; private set; }
    }
}