using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.Entities.Store
{
    public class Order : EntityBase
    {
        public Order() 
            : base(Guid.Empty)
        {
        }

        public decimal TotalPrice { get; private set; }
        public Guid UserIdentifier { get; private set; }
        public IEnumerable<OrderProduct> ProductsItems { get; private set; }
        public StatusOrder StatusOrder{get; private set;}
        public TypePayment TypePayment { get; private set; }

        public void SetTotalPrice(decimal totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public void SetStatusOrder(StatusOrder statusOrder)
        {
            StatusOrder = statusOrder;
        }
    }
}