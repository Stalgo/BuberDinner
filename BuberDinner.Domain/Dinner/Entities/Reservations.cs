using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed record GuestId(Guid Id) { }

    public sealed record BillId(Guid Id) { }

    public sealed class Reservation : AggregateRoot<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public DateTime ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }

        private Reservation(
            ReservationId id,
            BillId billId,
            GuestId guestId,
            ReservationStatus reservationStatus,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            BillId = billId;
            GuestId = guestId;
            ReservationStatus = reservationStatus;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(BillId billId, GuestId guestId, ReservationStatus reservationStatus)
        {
            return new(
                ReservationId.CreateUnique(),
                billId,
                guestId,
                reservationStatus,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
