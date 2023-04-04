using BeyondNet.Patterns.NetDdd.Entities;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public class EAlbumStatus : Enumeration
    {
        public static EAlbumStatus Pending = new(1, nameof(Pending));
        public static EAlbumStatus InLab = new(2, nameof(InLab));
        public static EAlbumStatus InSales = new(3, nameof(InSales));
        public static EAlbumStatus Closed = new(4, nameof(Closed));
        public static EAlbumStatus Canceled = new(5, nameof(Canceled));

        public EAlbumStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
