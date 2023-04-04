using SkillMap.SharedKernel.Domain.ValueObjects;

namespace BackOffice.Domain.Tags
{
    public class TagName : MyString
    {
        private TagName(string value) : base(value)
        {
        }

        public static TagName Create(string value)
        {
            return new TagName(value);
        }
    }
}
