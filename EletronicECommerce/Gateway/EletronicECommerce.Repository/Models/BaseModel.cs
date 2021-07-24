using System;

namespace EletronicECommerce.Repository.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
    }
}