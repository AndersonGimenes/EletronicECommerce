using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
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
    public class ProductController : GenericControllerBase
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
            return base.Execute(() => 
            {
                var product = _mapper.Map<Product>(ProductRequest);
                return _mapper.Map<ProductResponse>(_registerProductUseCase.Create(product));

            }, nameof(Product));
        }
    }
}