using System.Text;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Exceptions;

namespace EletronicECommerce.Domain.Validation
{
    public static class PaymentExtensionsValidation
    {
        public static void Validate(this Payment payment)
        {
            var stringBuilder = new StringBuilder();

            ValidateField(payment.CardNumber, nameof(Payment.CardNumber), stringBuilder);
            ValidateField(payment.Holder, nameof(Payment.Holder), stringBuilder);
            ValidateField(payment.ExpirationDate, nameof(Payment.ExpirationDate), stringBuilder);
            ValidateField(payment.SecurityCode, nameof(Payment.SecurityCode), stringBuilder);
            ValidateField(payment.Brand, nameof(Payment.Brand), stringBuilder);
            ValidateField(payment.Amount, nameof(Payment.Amount), stringBuilder);
            ValidateField(payment.Installments, nameof(Payment.Installments), stringBuilder);
            
            if(stringBuilder.Length > 0)
                throw new DomainException(stringBuilder.ToString());
        }

        private static void ValidateField(dynamic value, string field, StringBuilder stringBuilder)
        {            
            if(value.GetType() == typeof(string) && string.IsNullOrEmpty(value))
                    stringBuilder.Append($"Please fill the field {field}.");

            if(value.GetType() == typeof(int) && (int)value == default)
                    stringBuilder.Append($"Please fill the field {field}.");
        }

    }
}