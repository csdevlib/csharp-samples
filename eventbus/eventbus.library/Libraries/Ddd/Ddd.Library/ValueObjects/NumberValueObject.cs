using System;

namespace DDD.Library.ValueObjects
{
	public class NumberValueObject: ValueObject<Int32>
	{

        private NumberValueObject(Int32 value):base(value)
		{
		}

        public static NumberValueObject Create(Int32 value)
        {
            return new NumberValueObject(value);
        }

        public override void BusinessRules()
        {
           
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}

