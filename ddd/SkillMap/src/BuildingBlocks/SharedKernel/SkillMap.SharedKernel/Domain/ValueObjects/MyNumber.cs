namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class MyNumber : ValueObject<MyNumber>  
{
    public int Value { get; }

    public MyNumber(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString(NumberFormatInfo.InvariantInfo);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
