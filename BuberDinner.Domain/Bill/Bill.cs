using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill
{
    public sealed class Bill : AggregateRoot<Guid>
    {
        private Guid _dinnerId
        public Bill(Guid id) : base(id)
        {
        }
    }
}
