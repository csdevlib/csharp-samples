using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Companies
{
    public class CompanyName : MyString
    {
        private CompanyName(string value) : base(value)
        {
        }

        public static CompanyName Create(string value)
        {
            return new CompanyName(value);
        }
    }
}
