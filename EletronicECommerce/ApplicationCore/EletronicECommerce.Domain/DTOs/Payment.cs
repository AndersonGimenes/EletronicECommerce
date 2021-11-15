using System;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.ValeuObjects;

namespace EletronicECommerce.Domain.DTOs
{
    public class Payment
    {
        public string MerchantOrderId { get; private set; }
        public string CardNumber { get; private set; }
        public string Holder { get; private set; }
        public string ExpirationDate { get; private set; }
        public string SecurityCode { get; private set; }
        public string Brand { get; private set; }
		public int Amount { get; private set; }
        public int Installments { get; private set; }
        public Name Customer { get; private set; }
        public TypePayment Type { get; private set; }	
        public Guid CustomerId { get; private set; }
        
        public void SetCustomer(Name customer)
        {
            Customer = customer;
        }
    }
}