using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies
{
    public class CompanyTalent : ValueObject<CompanyEmployee>
    {
        public string TalentId { get; init; }
        public string Name { get; init; }

        private CompanyTalent(string talentId, string name)
        {
            TalentId = talentId;
            Name = name;
        }

        public static CompanyTalent Create(string talentId, string name)
        {
            return new CompanyTalent(talentId, name);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TalentId;
            yield return Name;
        }
    }
}
