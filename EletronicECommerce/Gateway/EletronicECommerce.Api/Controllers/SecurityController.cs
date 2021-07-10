using System;
using AutoMapper;
using EletronicECommerce.Api.Models.User;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Infrastructure.Security;
using EletronicECommerce.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]  
    [Authorize]
    public class SecurityController : ControllerBase
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
            try
            {
                var user = _registerUserUseCase.CheckUser(_mapper.Map<User>(userRequest));

                if(user is null)    
                    return Unauthorized();

                var token = TokenHandler.GenerateToken(user);

                return Ok(new UserResponse(token));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTestValidateToken()
        { 
            try
            {
                return Ok("Authorized!!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}