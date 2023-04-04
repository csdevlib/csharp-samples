using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class AlbumType: Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public AlbumType(string description)
        {
            Description = description;
        }
    }
}
