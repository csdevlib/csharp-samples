using MusicStore.Shared.Domain.Interfaces;

namespace MusicStore.Shared.Interfaces
{
    public interface IReadRepository<T, K> where T: IAggregateRoot
    {
        Task<IReadOnlyList<T>> Find();

        Task<T> FindById(K id);

        Task<bool> Exists(K id);
    }
}
