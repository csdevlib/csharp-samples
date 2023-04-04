
namespace SkillMap.SharedKernel.Domain.Interfaces;

public interface IRepositoryUoW
{
    IUnitOfWork UnitOfWork { get; }      
}
