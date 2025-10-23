using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            _ = config.NewConfig<RegisterRequest, RegisterCommand>(); //not nessesary, just for convention
            _ = config.NewConfig<LoginRequest, LoginQuery>();
            _ = config
                .NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(static dest => dest.Id, static src => src.User.Id.Value)
                .Map(static dest => dest.FirstName, static src => src.User.FirstName)
                .Map(static dest => dest.LastName, static src => src.User.LastName)
                .Map(static dest => dest.Email, static src => src.User.Email)
                .Map(static dest => dest.Token, static src => src.Token);
        }
    }
}
