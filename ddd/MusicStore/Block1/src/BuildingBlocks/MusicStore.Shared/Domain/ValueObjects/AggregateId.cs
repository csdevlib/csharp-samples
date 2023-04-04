namespace MusicStore.Shared.Domain.ValueObjects
{
    public class AggregateId<TModel, T> : IdValueObject<T>
    {
        protected AggregateId(T value) : base(value)
        {
        }

        public static AggregateId<TModel, T> From(T value) => new AggregateId<TModel, T>(value);
    }
}
