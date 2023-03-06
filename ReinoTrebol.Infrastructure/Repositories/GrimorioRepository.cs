using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories
{
    internal class GrimorioRepository : IGrimorioRepository
    {
        private readonly ApplicationContext context;

        public GrimorioRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Grimorio>> ListarGrimorios(Expression<Func<Grimorio, bool>>? predicate = null,
            Func<IQueryable<Grimorio>, IIncludableQueryable<Grimorio, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<Grimorio> query = context.Grimorios;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (include is not null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }
    }
}
