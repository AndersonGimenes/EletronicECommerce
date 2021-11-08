using System;
using AutoMapper;
using EletronicECommerce.Api.Controllers.Base;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Infrastructure.Security;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class SecurityController : GenericControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private IMapper _mapper;

        public SecurityController(IMapper mapper, IRegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _mapper = mapper;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserRequest userRequest)
        {             
            return base.Execute(() => 
            {
                var user = _registerUserUseCase.CheckUser(_mapper.Map<User>(userRequest));
                if(user is null)
                    throw new UnauthorizedAccessException("Unauthorized Access");

                return TokenHandler.GenerateToken(user);

            }, "Token");
        }

        [HttpGet(nameof(CreateAdminUser))]
        public IActionResult CreateAdminUser()
        {
            return base.Execute(() => 
            {
                var user = new User(Settings.AdminUser, Settings.AdminPassword, Guid.Empty, RoleType.MasterUser);
                _registerUserUseCase.Create(user);

                return null;

            }, string.Empty);
        }

        [HttpGet]
        public IActionResult GetTestValidateToken()
        { 
            return base.Execute(() => 
            {
                return "Authorized!!";

            }, string.Empty);
        }    
    }
}