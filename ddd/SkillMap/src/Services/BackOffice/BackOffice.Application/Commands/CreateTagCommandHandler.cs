using BackOffice.Domain.Tags;
using MediatR;
using SkillMap.EventBus.Commands;
using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Application.Commands
{
    public class CreateTagCommandHandler : AbstractCommandHandlerAsync<CreateTagCommand>
    {
        private readonly IWriteTagRepository writeTagRepository;

        public CreateTagCommandHandler(IMediator mediator,
                                       IWriteTagRepository writeTagRepository) : base(mediator)
        {
            this.writeTagRepository = writeTagRepository;
        }

        protected override async Task Handle(CreateTagCommand command, CancellationToken cancellationToken)
        {
            var tag = Domain.Tags.Tag.Create(AggregateId<Domain.Tags.Tag, string>.From(Guid.NewGuid().ToString()),
                                             TagName.Create(command.Name),
                                             TagDescription.Create(command.Description));

            if (!tag.IsValid) throw new ApplicationException($"Invalid data ocurred. Validation Errors: {tag.BrokenRules}");

            //await writeTagRepository.Save(tag);

            await Publish(tag.DomainEvents);
        }
    }
}
