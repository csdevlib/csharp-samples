using BackOffice.Domain.Talents.Validators;
using SkillMap.SharedKernel.Domain;
using SkillMap.SharedKernel.Domain.ValueObjects;
using SkillMap.Validator.Abstractions;

namespace BackOffice.Domain.Companies.Talents
{
    public class Talent : AggregateRoot<Talent>
    {
        public AggregateId<Talent,string> Id { get; init; }
        public TalentCompany Company { get; init; }
        public TalentName Name { get; init; }
        private List<Address> _addresses;
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public TalentStatus Status { get; private set; }

        private Talent(AggregateId<Talent,string> id, TalentName name, TalentCompany company)
        {
            Id = id;
            Company = company;
            Name = name;
            Status = TalentStatus.Active;

            AddValidatorRules();

            ValidateRules(this);
        }

        public static Talent Create(AggregateId<Talent, string> id, TalentName name, TalentCompany company)
        {
            return new Talent(id, name, company);
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
            AddDomainValidators(new List<WrapperAbstractValidator<Talent>>
            {
                new TalentValidator(),
            });
        }

      
    }
}
