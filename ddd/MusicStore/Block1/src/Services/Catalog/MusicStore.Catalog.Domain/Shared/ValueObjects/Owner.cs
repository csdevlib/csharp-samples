namespace MusicStore.Catalog.Domain.Shared.ValueObjects
{
    public class Owner : ValueObject
    {
        public string Id { get; set; }
        public string UserName { get; private set; }

        private Owner(string id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public static Owner Create(string id, string userName)
        {
            return new Owner(id, userName);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return UserName;
        }
    }
}
