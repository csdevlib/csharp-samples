using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Companies.Talents
{
    public class TalentName : MyString
    {
        private TalentName(string value) : base(value)
        {
        }
        
        public static TalentName Create(string value)
        {
            return new TalentName(value);
        }
    }
}
