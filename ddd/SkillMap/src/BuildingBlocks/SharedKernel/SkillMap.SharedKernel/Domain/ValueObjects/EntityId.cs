namespace SkillMap.SharedKernel.Domain.ValueObjects;

public class EntityId<T> : Id<T>
{
    protected EntityId(T value) : base(value)
    {
    }

    public static EntityId<T> From(T value) => new EntityId<T>(value);
}
