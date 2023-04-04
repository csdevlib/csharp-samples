using SkillMap.SharedKernel.Domain;

namespace BackOffice.Domain.Tags
{
    public class TagStatus : Enumeration
    {
        public TagStatus(int id, string name) : base(id, name)
        {
        }

        public static TagStatus Active = new(1, nameof(Active));
        public static TagStatus Inactive = new(2, nameof(Inactive));
    }
}
