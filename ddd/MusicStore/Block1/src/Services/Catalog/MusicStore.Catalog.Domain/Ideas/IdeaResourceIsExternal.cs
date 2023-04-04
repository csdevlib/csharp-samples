namespace MusicStore.Catalog.Domain.Ideas
{
    public class IdeaResourceIsExternal : BoolValueObject
    {
        private IdeaResourceIsExternal(bool value) : base(value)
        {
        }

        public static IdeaResourceIsExternal Create(bool value)
        {
            return new IdeaResourceIsExternal(value);
        }
    }
}
