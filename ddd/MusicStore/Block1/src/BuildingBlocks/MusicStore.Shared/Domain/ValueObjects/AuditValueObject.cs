namespace MusicStore.Shared.Domain.ValueObjects
{
    public class Audit : ValueObject
    {
        public string UserCreator { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string UserUpdater { get; private set; }
        public Nullable<DateTime> UpdatedOn { get; private set; }

        private Audit(string userCreator)
        {
            UserCreator = userCreator;
            CreatedOn = DateTime.UtcNow;
        }

        public static Audit Create(string userCreator)
        {
            return new Audit(userCreator);
        }

        public Audit Update(Audit audit, string userUpdater)
        {
            audit.UserUpdater = userUpdater;
            audit.UpdatedOn = DateTime.UtcNow;

            return audit;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return UserCreator;
            yield return CreatedOn;
            yield return UserUpdater;
            yield return UpdatedOn;
        }
    }
}
