using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.Payment;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    public class OrderController : GenericControllerBase
    {
        private readonly IRegisterPaymentUseCase _registerPaymentUseCase;
        private readonly IMapper _mapper;

        public OrderController(IRegisterPaymentUseCase registerPaymentUseCase, IMapper mapper)
        {
            _registerPaymentUseCase = registerPaymentUseCase;
            _mapper = mapper;
        }

        [HttpPost(nameof(SendPayment))]
        public IActionResult SendPayment([FromBody] PaymentRequest paymentRequest)
        {
            return base.Execute(() => 
            {
                var payment = _mapper.Map<Payment>(paymentRequest);                
                return _registerPaymentUseCase.SendPayment(payment);

            }, "Ok");
        } 
    }
}