namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaResourceIsShared : BoolValueObject
    {
        public static IdeaResourceIsShared Default => Create(false);

        private IdeaResourceIsShared(bool value) : base(value)
        {
        }

        public static IdeaResourceIsShared Create(bool value)
        {
            return new IdeaResourceIsShared(value);
        }
    }
}
