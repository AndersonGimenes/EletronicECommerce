using System;
using System.Runtime.Serialization;

namespace EletronicECommerce.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {

        }

        protected DomainException(string message, Exception innerException)
            : base(message, innerException)
        {

        } 

        protected DomainException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext)
        {
            
        }
    }
}