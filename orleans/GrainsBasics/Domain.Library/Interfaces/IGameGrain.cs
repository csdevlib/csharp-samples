namespace Domain.Library.Interfaces
{
    public interface IGameGrain
    {
        Task<Guid> GetPrimaryKey();
    }
}