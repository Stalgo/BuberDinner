using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
