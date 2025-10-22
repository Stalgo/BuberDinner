using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public double Value { get; private set; }

        private Rating(double value)
        {
            switch (value)
            {
                case < 0:
                case > 5:
                    throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 0 and 5.");
                default:
                    break;
            }
            Value = value;
        }

        public static Rating Create(double value)
        {
            return new Rating(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
