using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public Menu(MenuId id)
            : base(id) { }
    }
}
