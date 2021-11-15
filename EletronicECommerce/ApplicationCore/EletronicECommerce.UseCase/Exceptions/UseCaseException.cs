using System;
using System.Runtime.Serialization;

namespace EletronicECommerce.UseCase.Exceptions
{
    [Serializable]
    public class UseCaseException : Exception
    {
        public UseCaseException(string message)
            : base(message)
        {

        }

        protected UseCaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected UseCaseException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext)
        {
            
        }
    }
}