using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies.Talents
{
    public class TalentCompany : ValueObject<TalentCompany>
    {
        public string CompanyId { get; init; }
        public string Name { get; init; }

        private TalentCompany(string companyId, string name)
        {
            CompanyId = companyId;
            Name = name;
        }

        public static TalentCompany Create(string companyId, string name)
        {
            return new TalentCompany(companyId, name);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CompanyId;
            yield return Name;
        }
    }
}
