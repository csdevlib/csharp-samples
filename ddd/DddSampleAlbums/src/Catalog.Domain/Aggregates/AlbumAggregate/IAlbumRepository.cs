using BeyondNet.Patterns.NetDdd.Repositories.Contracts;

namespace Catalog.Domain.Aggregates.AlbumAggregate
{
    public interface IAlbumRepository : IAsyncRepository<Album, string>
    {
    }
}
