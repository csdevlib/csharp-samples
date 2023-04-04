using BeyondNet.Patterns.NetDdd.Core.Interfaces;
using ESStore.Infrastructure.Store;
using System.Threading.Tasks;

namespace ESStore.Application.Contracts.Store
{
    public interface IAggregateStore : IAggregateStoreLoader
    {
        Task Save<TAggregate, T>(TAggregate aggregate, T id, AggregateStoreOptions options = null) where TAggregate : IAggregateRoot;
    }
}
