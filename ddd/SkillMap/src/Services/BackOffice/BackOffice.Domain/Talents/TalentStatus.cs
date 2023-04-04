using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies.Talents
{
    public class TalentStatus : Enumeration
    {
        public TalentStatus(int id, string name) : base(id, name)
        {
        }
        
        public static TalentStatus Active = new(1, nameof(Active));
        public static TalentStatus Inactive = new(1, nameof(Inactive));
    }
}
