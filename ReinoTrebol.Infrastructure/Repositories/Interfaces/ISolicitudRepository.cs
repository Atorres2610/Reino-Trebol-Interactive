using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;

namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<List<Solicitud>> ListarSolicitudes(Func<IQueryable<Solicitud>, IIncludableQueryable<Solicitud, object?>>? include = null, bool disableTracking = true);
        Task<int> GuardarSolicitud(Solicitud solicitud);
        Task<Solicitud?> ObtenerSolicitud(int idSolicitud, Func<IQueryable<Solicitud>, IIncludableQueryable<Solicitud, object?>>? include = null, bool disableTracking = true);
        void EliminarSolicitud(Solicitud solicitud);
    }
}
