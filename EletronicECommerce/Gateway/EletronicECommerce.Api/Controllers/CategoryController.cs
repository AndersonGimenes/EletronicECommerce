using System;
using AutoMapper;
using EletronicECommerce.Api.Models;
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

                return Ok(new GenericResponse(result: true, errorMessage: string.Empty, categoryResponse, nameof(Category)));
               
            }
            catch(Exception ex)
            {
                return BadRequest(new GenericResponse(result: false, ex.Message, null, string.Empty));
            }
        }
    }
}