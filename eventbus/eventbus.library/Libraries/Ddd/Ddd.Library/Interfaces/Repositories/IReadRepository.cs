using System;
namespace DDD.Library.Interfaces.Repositories
{
	public interface IReadRepository<TId, TTable>
	{
		Task<TTable[]> Fetch();
        Task<TTable> FetchById(TId id);
    }
}

