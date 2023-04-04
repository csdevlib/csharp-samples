
namespace MusicStore.Shared.Interfaces
{
    public interface IRepositoryUoW
    {
        IUnitOfWork UnitOfWork { get; }      
    }
}
