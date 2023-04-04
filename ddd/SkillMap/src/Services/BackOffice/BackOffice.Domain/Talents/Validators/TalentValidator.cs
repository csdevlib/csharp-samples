using BackOffice.Domain.Companies.Talents;
using FluentValidation;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Talents.Validators
{
    public class TalentValidator : WrapperAbstractValidator<Talent>
    {
        public TalentValidator()
        {
            RuleFor(talent => talent.Name).NotNull().NotEmpty();
            RuleFor(talent => talent.Name.Value.Length).GreaterThan(5);
        }
    }
}
