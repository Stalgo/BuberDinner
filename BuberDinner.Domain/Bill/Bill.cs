using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill
{
    public sealed record DinnerId(Guid Id) { }

    public sealed record GuestId(Guid Id) { }

    public sealed record HostId(Guid Id) { }

    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdateDateTime { get; }
        public Price Price { get; }

        private Bill(
            BillId id,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            Price price
        )
            : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdateDateTime = updatedDateTime;
        }

        public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
        {
            return new(BillId.CreateUnique(), dinnerId, guestId, hostId, DateTime.UtcNow, DateTime.UtcNow, price);
        }
    }
}
