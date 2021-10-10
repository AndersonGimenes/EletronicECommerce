using System;
using System.ComponentModel.DataAnnotations.Schema;
using EletronicECommerce.Repository.Models.SubModels;

namespace EletronicECommerce.Repository.Models
{
    public class CustomerModel : BaseModel
    {
        
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string DocumentNumber { get; private set; }
        public int DocumentType { get; private set; }
        [NotMapped]
        public AddressModel DeliveryAddess { get; private set; }
        [NotMapped]
        public AddressModel BillingAddress { get; private set; }
        public Guid User { get; private set; }

        internal CustomerModel CompleteMapper()
        {
            this.BillingAddress.SetCustumer(this.Id);
            this.BillingAddress.SetAddressType(nameof(this.BillingAddress));

            this.DeliveryAddess.SetCustumer(this.Id);
            this.DeliveryAddess.SetAddressType(nameof(this.DeliveryAddess));

            return this;
        }

    }
}