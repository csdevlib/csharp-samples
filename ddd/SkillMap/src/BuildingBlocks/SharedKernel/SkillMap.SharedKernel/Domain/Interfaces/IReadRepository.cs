namespace SkillMap.SharedKernel.Domain.Interfaces;

public interface IReadRepository<T, K> where T : class
{ 
    Task<IEnumerable<T>> Find();

    Task<T> FindById(K id);

    Task<bool> Exists(string value);
}
