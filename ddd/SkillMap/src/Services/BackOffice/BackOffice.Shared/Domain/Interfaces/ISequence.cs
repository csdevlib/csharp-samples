namespace BackOffice.Shared.Domain.Interfaces
{
    public interface ISequence
    {
        Task<int> GetNextValue<T>();
    }
}
