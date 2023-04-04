using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies
{
    public class CompanyTag : ValueObject<CompanyTag>
    {
        public string TagId { get; init; }
        public string Name { get; init; }

        private CompanyTag(string tagId, string name)
        {
            TagId = tagId;
            Name = name;    
        }

        public static CompanyTag Create(string tagId, string name)
        {
            return new CompanyTag(tagId, name);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TagId;
            yield return Name;
        }
    }
}
