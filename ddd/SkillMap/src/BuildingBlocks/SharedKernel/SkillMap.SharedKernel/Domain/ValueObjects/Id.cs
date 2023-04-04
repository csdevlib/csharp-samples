namespace SkillMap.SharedKernel.Domain.ValueObjects;

public abstract class Id<T> : ValueObject<Id<T>>  
{
    public T Value { get; }

    public Id(T value)
    {
        Guard(value);

        Value = value;
    }

    private void Guard(T value)
    {
        if (value == null)
            throw new InvalidEnumArgumentException($"{value} cannot be null");
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
   
}    
