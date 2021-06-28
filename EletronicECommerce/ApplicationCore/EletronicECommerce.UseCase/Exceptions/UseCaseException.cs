using System;

namespace EletronicECommerce.UseCase.Exceptions
{
    public class UseCaseException : Exception
    {
        public UseCaseException()
        {

        }

        public UseCaseException(string message)
            : base(message)
        {

        }

        public UseCaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }

}