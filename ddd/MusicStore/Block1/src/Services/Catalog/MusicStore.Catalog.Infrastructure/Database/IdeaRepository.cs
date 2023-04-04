using MusicStore.Catalog.Domain.Ideas;

namespace MusicStore.Catalog.Infrastructure.Database
{
    public class IdeaRepository : IIdeaRepository
    {
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Idea>> Find()
        {
            throw new NotImplementedException();
        }

        public Task<Idea> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Idea item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Idea item, string id)
        {
            throw new NotImplementedException();
        }
    }
}
