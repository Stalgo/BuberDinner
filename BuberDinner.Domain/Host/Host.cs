using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu
{
    public sealed class Dinner : AggregateRoot<Guid>
    {
        public Dinner(Guid id)
            : base(id) { }
    }
}
