using FluentValidation;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Companies.Validators
{
    public class CompanyValidator : WrapperAbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Name.Value.Length).GreaterThan(5);
        }
    }
}
