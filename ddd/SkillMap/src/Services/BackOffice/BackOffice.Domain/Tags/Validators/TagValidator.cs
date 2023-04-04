using FluentValidation;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Tags.Validators
{
    public class TagValidator : WrapperAbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(tag => tag.Name).NotNull().NotEmpty();
            RuleFor(tag => tag.Name.Value.Length).GreaterThan(5);
            RuleFor(tag => tag.Description).NotNull().NotEmpty();
        }
    }
}
