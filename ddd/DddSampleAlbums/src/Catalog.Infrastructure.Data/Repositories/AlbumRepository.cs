using Catalog.Domain.Aggregates.AlbumAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public Task<Album> CreateAsync(Album entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Album entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Album>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Album>> GetAsync(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Album>> GetAsync(Expression<Func<Album, bool>> predicate, Func<IQueryable<Album>, IOrderedQueryable<Album>> orderBy, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Album> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Album entity)
        {
            throw new NotImplementedException();
        }
    }
}
