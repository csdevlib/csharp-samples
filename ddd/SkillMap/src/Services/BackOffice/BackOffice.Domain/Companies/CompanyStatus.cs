using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Companies
{
    public class CompanyStatus : Enumeration
    {
        public CompanyStatus(int id, string name) : base(id, name)
        {
        }

        public static CompanyStatus Active = new(1, nameof(Active));
        public static CompanyStatus Inactive = new(2, nameof(Inactive));
        public static CompanyStatus InProject = new(3, nameof(InProject));
        public static CompanyStatus Deleted = new(4, nameof(Deleted));
    }
}
