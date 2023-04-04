using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Tags
{
    public class TagDescription : MyString
    {
        private TagDescription(string value) : base(value)
        {
        }

        public static TagDescription Create(string value)
        {
            return new TagDescription(value);
        }
    }
}
