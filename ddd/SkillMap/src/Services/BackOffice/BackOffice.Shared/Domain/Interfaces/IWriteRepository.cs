namespace BackOffice.Shared.Domain.Interfaces 
{ 
    public interface IWriteRepository<T, K> where T : IAggregateRoot
    {
        Task Insert(T item);
        
        Task Update(T item, K id);

        Task Delete(K id);      
    }
}
