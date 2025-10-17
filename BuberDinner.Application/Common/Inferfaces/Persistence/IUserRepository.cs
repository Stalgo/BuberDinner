using BuberDinner.Domain.User.Entities;

namespace BuberDinner.Application.Common.Inferfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
