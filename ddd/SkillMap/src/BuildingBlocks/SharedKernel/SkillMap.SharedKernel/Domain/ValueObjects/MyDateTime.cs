namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class MyDateTime : ValueObject<MyDateTime>
{
    public DateTime Date { get; init; }

    public MyDateTime(DateTime date)
    {
        Date = date;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Date;
    }
}
