using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public sealed record UserId(Guid Id) { }

    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<Guid> _upcomingDinnerIds = [];
        private readonly List<Guid> _pastDinnerIds = [];
        private readonly List<Guid> _pendingDinnerIds = [];
        private readonly List<Rating> _ratings = [];
        public string ProfileImage { get; } = string.Empty;
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public UserId UserId { get; }
        public AverageRating AverageRating { get; } = default!;

        public IReadOnlyList<Guid> UpcomingDinnerId => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<Guid> PastDinnerId => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<Guid> PendingDinnerId => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }

        private Guest(
            GuestId id,
            UserId userId,
            string firstName,
            string lastName,
            string profileImage,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            CreatedDateTime = createdDateTime;
            UpdateDateTime = updatedDateTime;
        }

        public static Guest Create(UserId userId, string firstName, string lastName, string profileImage)
        {
            return new(
                GuestId.CreateUnique(),
                userId,
                firstName,
                lastName,
                profileImage,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
