using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<Guid>
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        private MenuItem(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(new Guid(), name, description);
        }
    }
}
