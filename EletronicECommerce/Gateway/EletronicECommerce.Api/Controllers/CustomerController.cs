using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.Customer;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class CustomerController : GenericControllerBase
    {
        private readonly IRegisterCustomerUseCase _registerCustomerUseCase;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, IRegisterCustomerUseCase registerCustomerUseCase)
        {
            _registerCustomerUseCase = registerCustomerUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerRequest customerRequest)
        {
            return base.Execute(() => 
            {
                var customer = _mapper.Map<Customer>(customerRequest);                
                return _mapper.Map<CustomerResponse>(_registerCustomerUseCase.Create(customer));

            }, nameof(CustomerResponse));
        }
        
    }
}