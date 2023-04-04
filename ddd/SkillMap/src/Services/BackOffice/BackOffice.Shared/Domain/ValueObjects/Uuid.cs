using System.ComponentModel;

namespace BackOffice.Shared.Domain.ValueObjects
{
    public class Uuid : ValueObject
    {
        public string Value { get; }

        public Uuid(string value)
        {
            Guard(value);
            Value = value;
        }

        private void Guard(string value)
        {
            if (!Guid.TryParse(value, out var Uuid))
                throw new InvalidEnumArgumentException($"{value} is not a valid GUID");
        }

        public override string ToString()
        {
            return Value;
        }

        public static Uuid Random()
        {
            return new Uuid(Guid.NewGuid().ToString());
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as Uuid;
            if (item == null) return false;

            return Value == item.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
