namespace MusicStore.Catalog.Application.Commands
{

    public class CreateIdeaCommandHandler : IRequestHandler<CreateIdeaCommand, bool>
    {
        private readonly IMediator _mediator;

        private readonly IIdeaRepository _ideaRepository;

        public CreateIdeaCommandHandler(IMediator mediator, IIdeaRepository ideaRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
            _ideaRepository = ideaRepository ?? throw new ArgumentNullException(nameof(ideaRepository));
        }

        public Task<bool> Handle(CreateIdeaCommand request, CancellationToken cancellationToken)
        {
            var id = AggregateId<Idea, string>.From(Guid.NewGuid().ToString());

            
            // TODO: Refactoring Owner
            var idea = Idea.Create(id, IdeaName.Create(request.Name), IdeaDescription.Create(request.Description), Owner.Create("foo", "beyondnet"));

            request.Tags.ToList().ForEach(tag => idea.AddTag(Tag.Create(tag)));

            request.Resources.ToList().ForEach(resource => idea.AddResource(IdeaResourceName.Create(resource.Name), 
                                                                            IdeaResourcePath.Create(resource.Path),
                                                                            IdeaResourceIsExternal.Create(resource.IsExternal)));

            _ideaRepository.Insert(idea);

            return Task.FromResult(true);
        }
    }
}

