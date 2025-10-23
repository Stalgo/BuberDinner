using BuberDinner.Domain.User.ValueObjects; // do a manual map, and use primitive type for id

namespace BuberDinner.Contracts.Authentication
{
    public record AuthenticationResponse(UserId Id, string FirstName, string LastName, string Email, string Token);
}
