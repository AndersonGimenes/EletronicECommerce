using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.Order;
using EletronicECommerce.Api.Models.Payment;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    public class OrderController : GenericControllerBase
    {
        private readonly IRegisterOrderUseCase _registerOrderUseCase;
        private readonly IRegisterPaymentUseCase _registerPaymentUseCase;
        private readonly IMapper _mapper;

        public OrderController(IRegisterOrderUseCase registerOrderUseCase, IRegisterPaymentUseCase registerPaymentUseCase, IMapper mapper)
        {
            _registerOrderUseCase = registerOrderUseCase;
            _registerPaymentUseCase = registerPaymentUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderRequest orderRequest)
        {
            return base.Execute(() => 
            {
                var order = _mapper.Map<Order>(orderRequest);                
                
                return _mapper.Map<OrderResponse>(_registerOrderUseCase.Create(order));

            }, nameof(OrderResponse));
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