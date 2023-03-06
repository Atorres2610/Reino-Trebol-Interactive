using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationContext context;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            context.Database.RollbackTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task ReloadAsync(object entity)
        {
            await context.Entry(entity).ReloadAsync();
        }
    }
}
