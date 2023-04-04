namespace MusicStore.Shared.Domain.ValueObjects
{
    public class PathValueObject : ValueObject
    {
        public string Value { get; }

        public PathValueObject(string value)
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
