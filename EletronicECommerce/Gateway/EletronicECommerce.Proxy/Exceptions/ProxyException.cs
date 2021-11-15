using System;
using System.Runtime.Serialization;

namespace EletronicECommerce.Proxy.Exceptions
{
    [Serializable]
    public class ProxyException : Exception
    {
        public ProxyException(string message)
            : base(message)
        {

        }

        protected ProxyException(string message, Exception innerException)
            : base(message, innerException)
        {

        } 

        protected ProxyException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext)
        {
            
        }
    }
}