namespace MusicStore.Catalog.Domain.Shared.ValueObjects
{
    public class Tag : StringValueObject
    {
        private Tag(string value) : base(value)
        {
        }

        public static Tag Create(string name)
        {
            return new Tag(name);
        }
    }
}
