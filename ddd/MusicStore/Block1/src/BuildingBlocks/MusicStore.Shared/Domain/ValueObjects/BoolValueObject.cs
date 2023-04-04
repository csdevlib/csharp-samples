namespace MusicStore.Shared.Domain.ValueObjects
{
    public class BoolValueObject : ValueObject
    {
        public bool Value { get; }

        public BoolValueObject(bool value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
