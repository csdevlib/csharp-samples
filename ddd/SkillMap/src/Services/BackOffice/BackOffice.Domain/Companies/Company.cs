using BackOffice.Domain.Companies.Events;
using BackOffice.Domain.Companies.Validators;
using SkillMap.SharedKernel.Domain;
using SkillMap.SharedKernel.Domain.ValueObjects;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Companies
{
    public partial class Company : AggregateRoot<Company>
    {
        public AggregateId<Company, string> Id { get; init; }
        public CompanyName Name { get; init; }
        public CompanyStatus Status { get; init; }

        private List<CompanyEmployee> _employees;
        public IReadOnlyCollection<CompanyEmployee> Employees => _employees.AsReadOnly();

        private List<CompanyEmployee> _recruiters;
        public IReadOnlyCollection<CompanyEmployee> Recruiters => _recruiters.AsReadOnly();

        private List<CompanyEmployee> _approvers;
        public IReadOnlyCollection<CompanyEmployee> Approvers => _approvers.AsReadOnly();

        private List<CompanyTalent> _talents;
        public IReadOnlyCollection<CompanyTalent> Talents => _talents.AsReadOnly();

        private List<CompanyTag> _tags;
        public IReadOnlyCollection<CompanyTag> Tags => _tags.AsReadOnly();

        private Company(AggregateId<Company, string> id, CompanyName name)
        {
            Id = id;
            Name = name;
            Status = CompanyStatus.Active;
            
            _employees = new List<CompanyEmployee>();
            _recruiters = new List<CompanyEmployee>();
            _approvers = new List<CompanyEmployee>();
            _talents = new List<CompanyTalent>();
            _tags = new List<CompanyTag>();

            AddValidatorRules();
            
            ValidateRules(this);

            if (IsValid) 
                AddDomainEvent(new CompanyAddedDomainEvent(id.Value, name.Value));
        }

        private void AddValidatorRules()
        {
            AddDomainValidators(new List<WrapperAbstractValidator<Company>>
            {
                new CompanyValidator(),
            });
        }
    }
}
