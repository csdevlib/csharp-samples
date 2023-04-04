using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies
{
    public class CompanyEmployee : ValueObject<CompanyEmployee>
    {
        public string EmployeeId { get; init; }
        public string Name { get; init; }

        private CompanyEmployee(string employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
        }

        public static CompanyEmployee Create(string employeeId, string name)
        {
            return new CompanyEmployee(employeeId, name);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmployeeId;
            yield return Name;
        }
    }
}
