using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.Category;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [Authorize(Roles = "MasterUser")]
    public class CategoryController : GenericControllerBase
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
            return base.Execute(() => 
            {
                var category = _mapper.Map<Category>(CategoryRequest);
                return _mapper.Map<CategoryResponse>(_registerCategoryUseCase.Create(category));

            }, nameof(CategoryResponse));
        }
    }
}