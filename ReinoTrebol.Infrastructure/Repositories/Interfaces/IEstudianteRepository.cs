using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> ListarEstudiantes(Expression<Func<Estudiante, bool>>? predicate = null, Func<IQueryable<Estudiante>,
    IIncludableQueryable<Estudiante, object?>>? include = null, bool disableTracking = true);
    }
}
