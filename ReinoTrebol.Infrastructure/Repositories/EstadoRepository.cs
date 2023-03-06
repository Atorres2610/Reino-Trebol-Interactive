using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ApplicationContext context;

        public EstadoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Estado>> ListarEstados(Expression<Func<Estado, bool>>? predicate = null, Func<IQueryable<Estado>, IIncludableQueryable<Estado, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<Estado> query = context.Estados;

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

        public async Task<Estado?> ObtenerEstado(int idEstado, bool disableTracking = true)
        {
            IQueryable<Estado> query = context.Estados;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x => x.IdEstado == idEstado);
        }
    }
}
