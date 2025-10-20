using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<Guid>
    {
        private readonly List<MenuSection> _sections = [];
        private readonly List<Guid> _dinnerIds = [];
        private readonly List<Guid> _menuReviewId = [];

        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public float AvrageRating { get; }
        public IReadOnlyList<Guid> DinnerIds => _dinnerIds.ToList();

        // same domain, might consider using abstracted id here
        public IReadOnlyList<Guid> MenuReviewIds => _dinnerIds.ToList();

        public Guid HostId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }

        // domain model should own its identity not database
        private Menu(
            Guid id,
            string name,
            string description,
            Guid hostId,
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
        public static Menu Create(string name, string description, Guid hostId)
        {
            return new(new Guid(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
