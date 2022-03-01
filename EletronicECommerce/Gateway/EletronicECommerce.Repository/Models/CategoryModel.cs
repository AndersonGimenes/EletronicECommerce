using System.Collections.Generic;

namespace EletronicECommerce.Repository.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; private set; }
        public IEnumerable<ProductModel> Products { get; private set; }
    }
}