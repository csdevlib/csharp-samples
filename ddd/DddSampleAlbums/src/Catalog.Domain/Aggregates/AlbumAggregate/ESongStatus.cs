using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class ESongStatus : Enumeration
    {
        public static ESongStatus Pending = new(1, nameof(Pending));
        public static ESongStatus Promoted = new(2, nameof(Promoted));
        public static ESongStatus Released = new(3, nameof(Released));
        public static ESongStatus Canceled = new(4, nameof(Canceled));

        public ESongStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
