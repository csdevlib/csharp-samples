namespace MusicStore.Catalog.Application.Queries
{
    public class GetIdeaListQueryHandler : IRequestHandler<GetIdeaListQuery, List<IdeaModel>>
    {
        private readonly IIdeaRepository repository;

        public GetIdeaListQueryHandler(IIdeaRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<IdeaModel>> Handle(GetIdeaListQuery request, CancellationToken cancellationToken)
        {
            var result = new List<IdeaModel>();

            var domainData = repository.Find();

            return Task.FromResult(result);
        }
    }
}
