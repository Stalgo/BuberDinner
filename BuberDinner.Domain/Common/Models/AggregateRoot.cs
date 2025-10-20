namespace BuberDinner.Domain.Common.Models
{
    // sharedkernel? add meditr Inotfication to enque events?
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(TId id)
            : base(id) { }
    }
}
