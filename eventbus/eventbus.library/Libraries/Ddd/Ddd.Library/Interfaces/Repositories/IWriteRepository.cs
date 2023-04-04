using System;
namespace DDD.Library.Interfaces.Repositories
{
	public interface IWriteRepository<TId, TTable> 
	{
		Task Save(TTable data, CancellationToken cancellationToken=default);
		Task Delete(TId id, CancellationToken cancellationToken=default);
	}
}

