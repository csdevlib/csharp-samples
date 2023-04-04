namespace SkillMap.SharedKernel.Domain.ValueObjects
{ 
    public class AggregateId<TModel, T> : Id<T> where T : class 
    {
        protected AggregateId(T value) : base(value)
        {
        }

        public static AggregateId<TModel, T> From(T value) => new AggregateId<TModel, T>(value);
    }
}
