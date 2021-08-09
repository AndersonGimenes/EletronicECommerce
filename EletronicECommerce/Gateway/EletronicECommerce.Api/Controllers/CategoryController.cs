using System;
using AutoMapper;
using EletronicECommerce.Api.Models.Category;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IRegisterCategoryUseCase _registerCategoryUseCase;
        private IMapper _mapper;

        public CategoryController(IMapper mapper, IRegisterCategoryUseCase registerCategoryUseCase)
        {
            _registerCategoryUseCase = registerCategoryUseCase;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest CategoryRequest)
        { 
            try
            {
                var category = _mapper.Map<Category>(CategoryRequest);

                var categoryResponse = _mapper.Map<CategoryResponse>(_registerCategoryUseCase.Create(category));

                return Ok(categoryResponse);
               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}