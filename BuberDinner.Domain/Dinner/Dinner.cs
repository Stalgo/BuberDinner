using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed record HostId(Guid Id) { }

    public sealed record MenuId(Guid Id) { }

    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = [];
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string ImageUrl { get; } = string.Empty;
        public Status Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public Location Location { get; }
        public DateTime StartedDateTime { get; }
        public DateTime EndedDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations.ToList();

        private Dinner(
            DinnerId id,
            string name,
            string description,
            string imageurl,
            Status status,
            Price price,
            bool isPublic,
            int maxGuests,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            Name = name;
            Description = description;
            ImageUrl = imageurl;
            Status = status;
            Price = price;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdateDateTime = updatedDateTime;
        }

        public static Dinner Create(
            string name,
            string description,
            string imageurl,
            Status status,
            Price price,
            bool isPublic,
            int maxGuests,
            Location location
        )
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                imageurl,
                status,
                price,
                isPublic,
                maxGuests,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
