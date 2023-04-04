namespace MusicStore.Shared.Domain.ValueObjects
{
    public class EntityId<T> : IdValueObject<T>
    {
        protected EntityId(T value) : base(value)
        {
        }

        public static EntityId<T> From(T value) => new EntityId<T>(value);
    }
}
