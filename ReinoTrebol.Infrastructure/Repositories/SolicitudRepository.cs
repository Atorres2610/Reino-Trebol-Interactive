using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.Infrastructure.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly ApplicationContext context;

        public SolicitudRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void EliminarSolicitud(Solicitud solicitud)
        {
            context.Solicitudes.Remove(solicitud);
        }

        public async Task<int> GuardarSolicitud(Solicitud solicitud)
        {
            await context.Solicitudes.AddAsync(solicitud);
            return solicitud.IdSolicitud;
        }

        public async Task<List<Solicitud>> ListarSolicitudes(Func<IQueryable<Solicitud>, IIncludableQueryable<Solicitud, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<Solicitud> query = context.Solicitudes;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public Task<Solicitud?> ObtenerSolicitud(int idSolicitud, Func<IQueryable<Solicitud>, IIncludableQueryable<Solicitud, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<Solicitud> query = context.Solicitudes;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            return query.FirstOrDefaultAsync(s => s.IdSolicitud == idSolicitud);
        }
    }
}
