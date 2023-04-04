using System.Globalization;

namespace MusicStore.Shared.Domain.ValueObjects
{
    public class IntValueObject : ValueObject
    {
        public int Value { get; }

        public IntValueObject(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString(NumberFormatInfo.InvariantInfo);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
