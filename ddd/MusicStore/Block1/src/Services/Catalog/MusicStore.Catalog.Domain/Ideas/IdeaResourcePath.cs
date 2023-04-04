namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaResourcePath : PathValueObject
    {
        private IdeaResourcePath(string value) : base(value)
        {
        }

        public static IdeaResourcePath Create(string path)
        {
            return new IdeaResourcePath(path);
        }
    }
}
