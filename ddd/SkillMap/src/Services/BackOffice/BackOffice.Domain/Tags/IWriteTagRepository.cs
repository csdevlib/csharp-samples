using SkillMap.SharedKernel.Domain.Interfaces;

namespace BackOffice.Domain.Tags
{
    public interface IWriteTagRepository :  IWriteRepository<Tag, string>
    {
    }
}
