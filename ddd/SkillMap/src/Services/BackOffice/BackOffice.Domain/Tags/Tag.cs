using BackOffice.Domain.Tags.Events;
using BackOffice.Domain.Tags.Validators;
using SkillMap.SharedKernel.Domain;
using SkillMap.SharedKernel.Domain.ValueObjects;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Tags
{
    public class Tag : AggregateRoot<Tag>
    {
        public AggregateId<Tag, string> Id { get; init; }
        public TagName Name { get; init; }
        public TagDescription Description { get; init; }
        public TagStatus Status { get; set; }

        private Tag(AggregateId<Tag, string> id, TagName name, TagDescription description)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = TagStatus.Active;

            AddValidatorRules();

            ValidateRules(this);

            if (IsValid)
                AddDomainEvent(new TagAddedDomainEvent(id.Value, name.Value));
        }

        public static Tag Create(AggregateId<Tag, string> id, TagName name, TagDescription description)
        {
            return new Tag(id, name, description);

            
        }

        private void AddValidatorRules()
        {
            AddDomainValidators(new List<WrapperAbstractValidator<Tag>>
            {
                new TagValidator(),
            });
        }
    }
}
