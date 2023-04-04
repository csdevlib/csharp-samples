namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class MyString : ValueObject<MyString>  
{
    public string Value { get; }

    public MyString(string value)
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
