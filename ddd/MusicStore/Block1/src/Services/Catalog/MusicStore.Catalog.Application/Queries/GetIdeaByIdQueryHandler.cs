namespace MusicStore.Catalog.Application.Queries
{
    public class GetIdeaByIdQueryHandler : IRequestHandler<GetIdeaByIdQuery, IdeaModel>
    {
        private readonly IIdeaRepository _repository;

        public GetIdeaByIdQueryHandler(IIdeaRepository repository)
        {
            _repository = repository;
        }

        public Task<IdeaModel> Handle(GetIdeaByIdQuery request, CancellationToken cancellationToken)
        {
            var allIdeas = _repository.FindById(request.id);

            var data = new IdeaModel("","",null,null);

            return Task.FromResult(data);
        }
    }
}
