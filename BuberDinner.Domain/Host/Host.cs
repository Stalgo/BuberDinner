using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed record UserId(Guid Id) { }

    public sealed record MenudId(Guid Id) { }

    public sealed record DinnerId(Guid Id) { }

    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenudId> _menueIds = [];
        private readonly List<DinnerId> _dinnerIds = [];

        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string ProfileImage { get; } = string.Empty;
        public UserId UserId { get; }
        public AverageRating AverageRating { get; } = default!;

        public IReadOnlyList<MenudId> MenudIds => _menueIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }

        private Host(
            HostId id,
            UserId userId,
            string firstName,
            string lastName,
            string profileImage,
            DateTime createDateTime,
            DateTime updateDateTime
        )
            : base(id)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            CreatedDateTime = createDateTime;
            UpdateDateTime = updateDateTime;
        }

        public static Host Create(UserId userId, string firstName, string lastName, string profileImage)
        {
            return new(
                HostId.CreateUnique(),
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
