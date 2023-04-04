namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaDescription : StringValueObject
    {
        private IdeaDescription(string value) : base(value)
        {
        }

        public static IdeaDescription Create(string value)
        {
            return new IdeaDescription(value);
        }
    }
}
