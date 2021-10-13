using System;

namespace EletronicECommerce.Repository.Models.SubModels
{
    public class StockModel
    {
        public int Id { get; private set; } 
        public decimal PurchasePrice { get; private set; }
        public int Quantity { get; private set; }
        public Guid Product { get; private set; }

        internal void SetProduct(Guid product)
        {
            this.Product = product;
        }
    }
}