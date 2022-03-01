using EletronicECommerce.Repository.Models.SubModels;
using System;
using System.Collections.Generic;

namespace EletronicECommerce.Repository.Models
{
    public class CustomerModel : BaseModel
    {

        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public string DocumentNumber { get; private set; }
        public int DocumentType { get; private set; }
        public IEnumerable<AddressModel> Addresses { get; private set; }
        public UserModel User { get; private set; }
        public Guid UserId { get; private set; }

    }
}