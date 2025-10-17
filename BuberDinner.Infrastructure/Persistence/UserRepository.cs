using BuberDinner.Application.Common.Inferfaces.Persistence;
using BuberDinner.Domain.User.Entities;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = [];

        // public IReadOnlyList<User> Users => _users.AsReadOnly();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
