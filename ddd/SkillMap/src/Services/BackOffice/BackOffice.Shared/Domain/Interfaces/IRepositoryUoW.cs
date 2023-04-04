
namespace BackOffice.Shared.Domain.Interfaces
{
    public interface IRepositoryUoW
    {
        IUnitOfWork UnitOfWork { get; }      
    }
}
