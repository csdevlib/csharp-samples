using BeyondNet.Patterns.NetDdd.Entities;
using System;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class File : Entity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }

        private File(string name, string path)
        {
            Id = Guid.NewGuid();
            Name = name;
            Path = path;
        }

        public static File Upload(string name, string path)
        {
            return new File(name, path);
        }
    }
}
