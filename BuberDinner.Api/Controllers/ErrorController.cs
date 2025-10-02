using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Models
{
    public class ErrorsController : ControllerBase
    {
        //fluentvalidation
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            (int statusCode, string message) = exception switch
            {
                IServiceException serviceException => (
                    (int)serviceException.StatusCode,
                    serviceException.ErrorMessage
                ),
                _ => (StatusCodes.Status500InternalServerError, "An  unexpected error ocurred"),
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
