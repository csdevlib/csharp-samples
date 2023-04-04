using System;
using DDD.Library.Core.Interfaces;

namespace DDD.Library.ValueObjects
{
    public abstract class ValueObject<TValue>
	{
        public TValue Value { get; private set; }

        protected ValueObject(TValue value)
        {
            this.BusinessRules();

            this.Value = value;
        }
        

        public abstract void BusinessRules();

        protected static bool EqualOperator(ValueObject<TValue> left, ValueObject<TValue> right)
        {           
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            if (right is null) throw new ArgumentNullException("Right value cannot be null");

            return ReferenceEquals(left, null) || left.Equals(right);

        }

        protected static bool NotEqualOperator(ValueObject<TValue> left, ValueObject<TValue> right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject<TValue>)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public ValueObject<TValue>? GetPropsCopy()
        {
            return this.MemberwiseClone() as ValueObject<TValue>;
        }
    }
}

