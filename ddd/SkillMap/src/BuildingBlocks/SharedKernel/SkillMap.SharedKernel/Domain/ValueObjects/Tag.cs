namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class Tag : ValueObject<Tag>
{
    public string Name { get; init; }
    public string Description { get; init; }

    private Tag(string name, string description)
    {
        Name = name;
        Description = description;  
    }

    public static Tag Create(string name, string description)
    {
        return new Tag(name, description);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Description;
    }
}
