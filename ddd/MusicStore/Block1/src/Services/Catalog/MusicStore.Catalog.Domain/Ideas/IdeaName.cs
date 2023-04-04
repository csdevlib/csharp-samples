namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaName : StringValueObject
    {
        private IdeaName(string value) : base(value)
        {
        }

        public static IdeaName Create(string value)
        {
            return new IdeaName(value);
        }
    }
}
