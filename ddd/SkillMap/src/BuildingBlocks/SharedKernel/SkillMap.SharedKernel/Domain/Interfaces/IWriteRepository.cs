namespace SkillMap.SharedKernel.Domain.Interfaces
{ 
    public interface IWriteRepository<T, K> where T : class
    {
        Task Save(T item);
        
        Task Delete(K id);      
    }
}
