namespace MusicStore.Shared.Domain.ValueObjects
{
    public class StringValueObject : ValueObject
    {
        public string Value { get; }

        public StringValueObject(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
