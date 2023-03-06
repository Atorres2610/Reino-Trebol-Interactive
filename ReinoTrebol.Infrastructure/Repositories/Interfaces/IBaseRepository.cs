namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task BeginTransactionAsync();
        void CommitTransaction();
        void RollBackTransaction();
        Task SaveChangesAsync();
        Task ReloadAsync(object entity);
    }
}
