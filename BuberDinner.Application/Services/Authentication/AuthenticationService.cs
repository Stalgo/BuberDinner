using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "", "", email, password);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // check if user already exits

            // create user (generate unique id)

            // create jwt token :w
            Guid userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
        }
    }
}
