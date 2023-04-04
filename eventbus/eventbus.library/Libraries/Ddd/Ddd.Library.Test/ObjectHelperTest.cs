using System;
using DDD.Library;
using DDD.Library.Helpers;
using DDD.Library.ValueObjects;

namespace DDD.Test
{

    [TestClass]
    public class ObjectHelperTest
	{
        class FooEntity : Entity
        {
            private FooEntity(string createdBy):base(createdBy)
            {
                
            }

            public override void BusinessRules()
            {
                //
            }

            public static FooEntity Create(string createdBy)
            {
                return new FooEntity(createdBy);
            }
        }

        public struct FooProps
        {
            public string Value { get; set; }
        }

        class FooValueObject : ValueObject<FooProps>
        {
            public FooValueObject(FooProps props) : base(props)
            {
            }

            public override void BusinessRules()
            {
                //
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return this.Value.Value;
            }  
        }

        [TestMethod]
		public void When_object_is_oftype_valueobject_return_Ok()
		{
            var result = ObjectHelper.IsValueObject(new FooValueObject(new FooProps()));

            Assert.IsTrue(result);            
		}

        [TestMethod]
        public void When_object_is_oftype_Entity_return_Ok()
        {         
            var result = ObjectHelper.IsEntity(FooEntity.Create("foo"));

            Assert.IsTrue(result);
        }
    }
}

