using System;
using AutoMapper;
using EletronicECommerce.Api.Models;
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
    public class CustomerController : ControllerBase
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
            try
            {
                //[Adjust response]
                var customer = _mapper.Map<Customer>(customerRequest);
                
                _registerCustomerUseCase.Create(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse(result: false, ex.Message, null, string.Empty));
            }
            
        }
        
    }
}