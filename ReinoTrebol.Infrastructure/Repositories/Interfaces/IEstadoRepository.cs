using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> ListarEstados(Expression<Func<Estado, bool>>? predicate = null, Func<IQueryable<Estado>,
    IIncludableQueryable<Estado, object?>>? include = null, bool disableTracking = true);

        Task<Estado?> ObtenerEstado(int idEstado, bool disableTracking = true);
    }
}
