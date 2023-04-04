using System;
using DDD.Library.Core.Interfaces;

namespace DDD.Library.Interfaces.Repositories
{
	public interface ITransactionRepository<TAggregate> where TAggregate: IAggregateRoot
    {
		Task Run(IAggregateRoot aggregateRoot, Func<Task> func, CancellationToken cancellationToken=default);
	}
}

