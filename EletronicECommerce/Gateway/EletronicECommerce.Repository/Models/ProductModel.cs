using EletronicECommerce.Repository.Models.SubModels;
using System;
using System.Collections.Generic;

namespace EletronicECommerce.Repository.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal SalePrice { get; private set; }
        public Guid CategoryId { get; private set; }
        public CategoryModel Category { get; private set; }
        public IEnumerable<StockModel> Stocks { get; private set; }       
    }
}