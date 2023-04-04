using System.ComponentModel;

namespace MusicStore.Shared.Domain.ValueObjects
{
    public abstract class IdValueObject<T> : ValueObject
    {
        public T Value { get; }

        public IdValueObject(T value)
        {
            Guard(value);

            Value = value;
        }

        private void Guard(T value)
        {
            if (value == null)
                throw new InvalidEnumArgumentException($"{value} cannot be null");
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
       
    }    
}
