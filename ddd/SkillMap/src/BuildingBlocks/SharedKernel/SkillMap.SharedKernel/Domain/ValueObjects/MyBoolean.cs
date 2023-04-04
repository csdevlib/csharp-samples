namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class MyBoolean : ValueObject<MyBoolean> 
{
    public bool Value { get; }

    public MyBoolean(bool value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
