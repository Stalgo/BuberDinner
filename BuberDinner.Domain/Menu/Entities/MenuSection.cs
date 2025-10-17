using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<Guid>
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
