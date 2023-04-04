using BackOffice.Domain.Employees.Validators;
using SkillMap.SharedKernel.Domain;
using SkillMap.SharedKernel.Domain.ValueObjects;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Employees
{
    public class Employee : AggregateRoot<Employee>
    {
        public AggregateId<Employee, string> Id { get; init; }
        public EntityId<string> CompanyId { get; init; }
        public EmployeeName Name { get; init; }
        public EmployeeStatus Status { get; init; }

        private List<Address> _addresses;
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        
        private Employee(AggregateId<Employee,string> id, EntityId<string> companyId, EmployeeName name)
        {
            Id = id;
            CompanyId = companyId;
  
            Name = name;    
            Status = EmployeeStatus.Active;

            _addresses = new List<Address>();

            AddValidatorRules();

            ValidateRules(this);
        }


        public static Employee Create(AggregateId<Employee,string> id,EntityId<string> companyId, EmployeeName name)
        {
            return new Employee(id, companyId, name);
        }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void RemoveAddress(Address address)
        {
            _addresses.Remove(address);
        }

        private void AddValidatorRules()
        {
            AddDomainValidators(new List<WrapperAbstractValidator<Employee>>
            {
                new EmployeeValidator(),
            });
        }
    }
}
