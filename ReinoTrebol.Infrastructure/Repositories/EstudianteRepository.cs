using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationContext context;

        public EstudianteRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Estudiante>> ListarEstudiantes(Expression<Func<Estudiante, bool>>? predicate = null, Func<IQueryable<Estudiante>, IIncludableQueryable<Estudiante, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<Estudiante> query = context.Estudiantes;

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
