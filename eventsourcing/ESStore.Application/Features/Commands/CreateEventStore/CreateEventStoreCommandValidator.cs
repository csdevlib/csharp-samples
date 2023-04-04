using FluentValidation;

namespace ESStore.Application.Features.Commands.CreateEventStore
{
    public class CreateEventStoreCommandValidator : AbstractValidator<CreateEventStoreCommand>
    {
        public CreateEventStoreCommandValidator()
        {
            RuleFor(p => p.Aggregate).NotEmpty().WithMessage("Event type cannot be null or empty").NotNull();
        }
    }
}
