using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu
{ //records
    // semantic boundries for larger projects, without violating context
    // but alot of duplication, and abstraction
    public sealed record DinnerId(Guid Id) { }

    public sealed record MenuReviewId(Guid Id) { }

    public sealed record HostId(Guid Id) { }

    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = [];
        private readonly List<DinnerId> _dinnerIds = [];
        private readonly List<MenuReviewId> _menuReviewId = [];

        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public float AvrageRating { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewId.ToList();

        public HostId HostId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }

        // domain model should own its identity not database
        private Menu(
            MenuId id,
            string name,
            string description,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdateDateTime = updatedDateTime;
        }

        // hides logic, factory method (ubiquites lang) why or how the menu is created
        // rather than just constructor
        public static Menu Create(string name, string description, HostId hostId)
        {
            return new(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
