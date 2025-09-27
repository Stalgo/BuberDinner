using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthencationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthencationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthenticationResult> registerResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );
            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }
            var firsterror = registerResult.Errors[0];
            if (firsterror is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists.");
            }
            return Problem();
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            );
            return Ok(response);
        }
    }
}
