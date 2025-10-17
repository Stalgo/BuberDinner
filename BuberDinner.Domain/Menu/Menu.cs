using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<Guid>
    {
        private readonly List<MenuSection> _sections = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public Menu(Guid id)
            : base(id) { }
    }
}
