using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Inferfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.User.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,
            CancellationToken cancellationToken
        )
        {
            // 1. Validate that the user doesnt exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2.  create user (generate unique id) and persist to db
            var user = new User(command.FirstName, command.LastName, command.Email, command.Password);
            _userRepository.Add(user);

            // 3. create jwt token :w
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
