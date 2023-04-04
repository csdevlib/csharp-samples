namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaStatus : Enumeration
    {
        public static IdeaStatus Created = new(1, nameof(Created));
        public static IdeaStatus Draft = new(2, nameof(Draft));
        public static IdeaStatus Released = new(3, nameof(Released));
        public static IdeaStatus Promoted = new(4, nameof(Promoted));
        public static IdeaStatus Closed = new(5, nameof(Closed));
        public static IdeaStatus Canceled = new(6, nameof(Canceled));

        public IdeaStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
