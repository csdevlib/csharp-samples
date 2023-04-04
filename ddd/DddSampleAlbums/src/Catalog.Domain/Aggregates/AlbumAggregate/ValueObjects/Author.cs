using BeyondNet.Patterns.NetDdd.ValueObjects.Contracts;
using System.Collections.Generic;

namespace Catalog.Domain.Aggregates.AlbumAggregate.ValueObjects
{
    public class Author : ValueObject
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
            yield return UserName;
        }

        private Author(string id, string name, string userName)
        {
            Id = id;
            Name = name;
            UserName = userName;
        }

        public static Author Create(string id, string name , string userName)
        {
            return new Author(id, name, userName);
        }
    }
}
