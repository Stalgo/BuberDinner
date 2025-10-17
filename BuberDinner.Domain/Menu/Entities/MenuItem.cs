using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        private MenuItem(MenuItemId id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
