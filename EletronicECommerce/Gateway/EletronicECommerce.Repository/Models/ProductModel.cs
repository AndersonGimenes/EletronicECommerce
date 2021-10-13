using System;
using System.ComponentModel.DataAnnotations.Schema;
using EletronicECommerce.Repository.Models.SubModels;

namespace EletronicECommerce.Repository.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal SalePrice { get; private set; }
        public Guid Category { get; private set; }
        [NotMapped]
        public StockModel Stock { get; private set; }

        internal ProductModel CompleteMapper()
        {
            if(Stock != null)
                Stock.SetProduct(this.Id);
                
            return this;
        }
    }
}