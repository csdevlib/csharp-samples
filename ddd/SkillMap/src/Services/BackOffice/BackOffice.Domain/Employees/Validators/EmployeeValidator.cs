using FluentValidation;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Employees.Validators
{
    public class EmployeeValidator : WrapperAbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Name.Value.Length).GreaterThan(5);
            RuleFor(x => x.CompanyId).NotNull();
        }
    }
}
