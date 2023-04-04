namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaResourceName : StringValueObject
    {
        private IdeaResourceName(string value) : base(value)
        {
        }

        public static IdeaResourceName Create(string name)
        {
            return new IdeaResourceName(name);
        }
    }
}
