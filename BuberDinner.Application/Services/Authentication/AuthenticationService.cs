using System.Runtime.CompilerServices;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            //1 validate the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                Console.WriteLine("User with given email does not exist");
                return null!;
            }

            //2. validate the password

            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate that the user doesnt exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            // 2.  create user (generate unique id) and persist to db
            var user = new User(firstName, lastName, email, password);
            _userRepository.Add(user);

            // 3. create jwt token :w
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
