using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EletronicECommerce.Repository.Models
{
    public class OrderModel : BaseModel
    {
        [NotMapped]
        public IEnumerable<Guid> Products { get; private set; }
        public Guid User { get; private set; }
        public Guid ProductId { get; private set; }
        public string StatusOrder{get; private set;}
        public string TypePayment { get; private set; }

        public void SetProductId(Guid productId)
        {
            this.ProductId = productId;
        }
    }
}