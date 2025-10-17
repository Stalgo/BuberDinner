using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    //yagni
    /// <summary>
    ///
    /// creating an abstraction of id for menu will make it cross domain boudries when used in other domains
    /// this will also create alot of boileplate code, but will create more type safety with strong types.
    ///
    /// </summary>
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
