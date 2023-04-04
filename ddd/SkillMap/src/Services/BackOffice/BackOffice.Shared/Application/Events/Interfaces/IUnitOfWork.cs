using System.Threading.Tasks;

namespace BackOffice.Shared.Application.Events.Interfaces
{ 
    public interface IUnitOfWork
    {
        bool IsThereATransactionInProgress();

        Task BeginTransaction();

        Task RollbackTransaction();

        Task CommitTransaction();
    }
}
