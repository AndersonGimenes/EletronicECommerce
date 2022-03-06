using System;

namespace EletronicECommerce.Repository.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; private set; }

        internal void SetCreateDate()
        {
            CreateDate = DateTime.Now;
        }
    }
}