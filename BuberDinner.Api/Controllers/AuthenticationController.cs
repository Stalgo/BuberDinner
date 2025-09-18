using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("[auth]")]
    public class AuthencationController : ControllerBase
    {
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok();
        }

        [Route("login")]
        public IActionResult Login(LoginRequest input)
        {
            return Ok();
        }
    }
}
