using System;
using System.Collections.Generic;
using EletronicECommerce.Repository.Models.SubModels;

namespace EletronicECommerce.Repository.Models
{
    public class OrderModel : BaseModel
    {
        public decimal TotalPrice { get; private set; }
        public string StatusOrder{get; private set;}
        public string TypePayment { get; private set; }           
        public Guid UserId { get; private set; } 
        public UserModel User { get; private set; }    
        public IEnumerable<OrderProductModel> Products { get; private set; }
    }
}