using System;
using AutoMapper;
using EletronicECommerce.Api.Models;
using EletronicECommerce.Api.Models.Product;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IRegisterProductUseCase _registerProductUseCase;
        private IMapper _mapper;

        public ProductController(IMapper mapper, IRegisterProductUseCase registerProductUseCase)
        {
            _registerProductUseCase = registerProductUseCase;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] ProductRequest ProductRequest)
        { 
            try
            {
                var product = _mapper.Map<Product>(ProductRequest);

                var productResponse = _mapper.Map<ProductResponse>(_registerProductUseCase.Create(product));

                return Ok(new GenericResponse(result: true, errorMessage: string.Empty, productResponse, nameof(Product)));
                               
            }
            catch(Exception ex)
            {
                return BadRequest(new GenericResponse(result: false, ex.Message, null, string.Empty));
            }
        }
    }
}