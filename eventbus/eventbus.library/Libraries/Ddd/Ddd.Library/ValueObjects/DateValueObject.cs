using System;

namespace DDD.Library.ValueObjects
{
    public class DateValueObject : ValueObject<DateTime>
    {
        private  DateValueObject(DateTime value) : base(value)
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static DateValueObject Create(DateTime value)
        {
            return new DateValueObject(value);
        }

        public override void BusinessRules()
        {
            
        }
    }
}

