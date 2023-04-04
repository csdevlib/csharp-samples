using System;
using Newtonsoft.Json.Linq;

namespace DDD.Library.ValueObjects
{
	public class StringValueObject:ValueObject<string>
	{
        private StringValueObject(string value):base(value)
		{
		}

        public static StringValueObject Create(string value)
        {
            return new StringValueObject(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        public override void BusinessRules()
        {
            if (string.IsNullOrEmpty(this.Value))
                throw new ArgumentNullException("Value cannot be null or empty");
        }
    }
}

