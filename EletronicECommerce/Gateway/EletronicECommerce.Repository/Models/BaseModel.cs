using System;

namespace EletronicECommerce.Repository.Models
{
    internal abstract class BaseModel
    {
        internal Guid Id { get; private set; }
        internal DateTime CreateDate { get; private set; }
    }
}