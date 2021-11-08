using System;
using System.Threading.Tasks;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Exceptions;
using EletronicECommerce.UseCase.Exceptions;
using EletronicECommerce.UseCase.Implementation.UseCase;
using EletronicECommerce.UseCase.Interfaces.Proxies;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Moq;
using Xunit;

namespace EletronicECommerce.UnitTest.UseCase
{
    public class RegisterPaymentUseCaseTest
    {
        private readonly Mock<IPaymentEngineProxy> _proxy;
        private readonly Mock<ICustomerRepository> _repository;
        private readonly RegisterPaymentUseCase _useCase;

        public RegisterPaymentUseCaseTest()
        {
            _proxy = new Mock<IPaymentEngineProxy>();
            _repository = new Mock<ICustomerRepository>();

            _useCase = new RegisterPaymentUseCase(_proxy.Object, _repository.Object);
        }

        //[To-do] improve this test
        [Fact]
        public void MustHaveAValidPaymentToBeCreated()
        {
            _repository.Setup(x => x.GetByUserIdentifier(It.IsAny<Guid>())).Returns( () => new Customer(new Name("João", "Da Silva"), null, null, null, Guid.Empty, Guid.Empty));
            _proxy.Setup(x => x.SendPayment(It.IsAny<Payment>())).Returns(() => Task.Run(() => new object()));

            var result = _useCase.SendPayment(NewPaymentObject());

            Assert.NotNull(result);
        }

        [Fact]
        public void IfThereIsNotCustomerMustTrhowException()
        {
            _repository.Setup(x => x.GetByUserIdentifier(It.IsAny<Guid>())).Returns( () => null);
            
            var ex = Assert.Throws<UseCaseException>(() => _useCase.SendPayment(NewPaymentObject()));
            Assert.Equal("Invalid customer", ex.Message);
        }
        
        [Theory]
        [InlineData(nameof(Payment.CardNumber), "", "Please fill the field CardNumber.")]
        [InlineData(nameof(Payment.Holder), "", "Please fill the field Holder.")]
        [InlineData(nameof(Payment.ExpirationDate), "", "Please fill the field ExpirationDate.")]
        [InlineData(nameof(Payment.SecurityCode), "", "Please fill the field SecurityCode.")]
        [InlineData(nameof(Payment.Brand), "", "Please fill the field Brand.")]
        [InlineData(nameof(Payment.Amount), 0, "Please fill the field Amount.")]
        [InlineData(nameof(Payment.Installments), 0, "Please fill the field Installments.")]
        public void MustGetSomeExceptionWhenValidateTheFields(string fieldName, dynamic value, string message)
        {
            var payment = NewPaymentObject();
            payment.GetType().GetProperty(fieldName).SetValue(payment, value);            
            
            var ex = Assert.Throws<DomainException>(() => _useCase.SendPayment(payment));
            Assert.Equal(ex.Message, message);
        }

        #region [ PRIVATE METHODS ]
        private Payment NewPaymentObject() => new Payment(
            "bbc7a54a-bd0d-4383-b5ce-16ef73fe5786",
            "1234123412341231",
            "Nome Do Cartao",
            "12/2030",
            "123",
            "Visa",
            15700,
            1,
            Guid.Parse("e8a01408-1981-4d48-9d2f-b378ae709489")
        );
        #endregion
    }
}