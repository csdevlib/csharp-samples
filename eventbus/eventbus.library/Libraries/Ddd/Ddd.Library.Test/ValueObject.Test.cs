using DDD.Library.ValueObjects;

namespace DDD.Test;

[TestClass]
public class ValueObjectTest
{
    
    public struct FooProps 
    {
        public string Foo { get; set; }

        public FooProps(string foo)
        {
            Foo = foo;
        }
    }

    public struct FooPropsComplex
    {
        public string Foo { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }

    public class FooValueObject : ValueObject<FooPropsComplex> 
    {
        public FooValueObject(FooPropsComplex value) : base(value)
        {
        }

        public override void BusinessRules()
        {
          
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value.Foo;
        }

    }

    public class ForSimpleValueObject : ValueObject<string>
    {
        public ForSimpleValueObject(string value) : base(value)
        {
        }

        public override void BusinessRules()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }

    [TestMethod]
    public void When_valueobject_is_simpleobject_unpack_obj()
    {        
      
        var vo = new ForSimpleValueObject("foo") { };

        var expectedResult = "foo";

        var result = vo.Value;

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void When_valueobject_is_primitive_unpack_obj()
    {       

        var vo = new ForSimpleValueObject("foo") { };

        var expectedResult = "foo";

        var result = vo.Value;

        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void When_valueobject_is_complexobject_unpack_obj()
    {
        var data = new Dictionary<string, string>();
        data.Add("1", "uno");
        data.Add("2", "dos");

        var props = new FooPropsComplex();
        props.Foo = "foo";
        props.Data = data;
        

        var vo = new FooValueObject(props) { };

        var expectedResult = props;

        var result = vo.Value;

        Assert.AreEqual(expectedResult, result);
    }
}
