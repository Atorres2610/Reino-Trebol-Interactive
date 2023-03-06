using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using System.Linq.Expressions;

namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface IGrimorioRepository
    {
        Task<List<Grimorio>> ListarGrimorios(Expression<Func<Grimorio, bool>>? predicate = null, Func<IQueryable<Grimorio>,
            IIncludableQueryable<Grimorio, object?>>? include = null, bool disableTracking = true);
    }
}
