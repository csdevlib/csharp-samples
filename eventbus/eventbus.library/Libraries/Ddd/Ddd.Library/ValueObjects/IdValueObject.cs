using System;

namespace DDD.Library.ValueObjects
{
    public class IdValueObject : ValueObject<string>
    {        
        private IdValueObject(string value) : base(value)
        {
        }

        public static IdValueObject Create()
        {
            return new IdValueObject(Guid.NewGuid().ToString());
        }

        public static string generate()
        {
            return Guid.NewGuid().ToString();
        }

        public static IdValueObject SetId(string id)
        {
            return new IdValueObject(id);
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

