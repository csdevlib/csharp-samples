using MusicStore.Shared.Interfaces;

namespace MusicStore.Catalog.Domain.Ideas
{
    public interface IIdeaRepository : IReadRepository<Idea, string>, IWriteRepository<Idea, string>
    {
    }
}
