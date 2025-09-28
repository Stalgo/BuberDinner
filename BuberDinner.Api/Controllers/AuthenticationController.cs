using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthencationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthencationController(
            IAuthenticationCommandService authenticationCommandService,
            IAuthenticationQueryService authenticationQueryService
        )
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );
            return authResult.Match(authResult => Ok(MapResult(authResult)), error => Problem(error));
        }

        private static AuthenticationResponse MapResult(AuthenticationResult authResult)
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
            ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email, request.Password);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(authResult => Ok(MapResult(authResult)), error => Problem(error));
        }
    }
}
