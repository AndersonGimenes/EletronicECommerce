using System;
using EletronicECommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EletronicECommerce.Api.Controllers.Base
{
    public abstract class GenericControllerBase : ControllerBase
    {
        public IActionResult Execute(Func<object> function, string objectName)
        { 
            try
            {       
                var result = function.Invoke();         
                return Ok(new GenericResponse(result: true, errorMessage: string.Empty, result, objectName));
            }
            catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(new GenericResponse(result: false, errorMessage: ex.Message, objectResult: null, objectName: string.Empty));
            }
            catch(Exception ex)
            {
                return BadRequest(new GenericResponse(result: false, errorMessage: ex.Message, objectResult: null, objectName: string.Empty));
            }
        }
    }
}