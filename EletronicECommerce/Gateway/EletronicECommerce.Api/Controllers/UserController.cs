using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class UserController : GenericControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IRegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UserRequest userRequest)
        {
            return base.Execute(() => 
            {
                var user = _mapper.Map<User>(userRequest);                
                _registerUserUseCase.Create(user);

                return new UserResponse(user.Email);

            }, nameof(User));
        }   
    }
}