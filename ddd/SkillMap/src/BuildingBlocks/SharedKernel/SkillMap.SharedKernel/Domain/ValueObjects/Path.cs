namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class Path : ValueObject<Path>  
{
    public string Value { get; }

    public Path(string value)
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
