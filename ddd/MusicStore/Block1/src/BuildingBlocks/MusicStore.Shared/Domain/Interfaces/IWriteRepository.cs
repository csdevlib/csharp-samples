using MusicStore.Shared.Domain.Interfaces;

namespace MusicStore.Shared.Interfaces
{
    public interface IWriteRepository<T, K> where T : IAggregateRoot
    {
        Task Insert(T item);

        Task Update(T item, K id);

        Task Delete(K id);      
    }
}
