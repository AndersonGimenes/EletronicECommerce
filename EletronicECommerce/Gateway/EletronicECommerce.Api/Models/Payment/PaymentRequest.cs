using System;

namespace EletronicECommerce.Api.Models.Payment
{
    public class PaymentRequest
    {
        public string MerchantOrderId { get; set; }     
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }		
		public int Amount { get; set; }
        public int Installments { get; set; }
		public int Type { get; set; }   
        public Guid CustomerId { get; set; }
    }
}