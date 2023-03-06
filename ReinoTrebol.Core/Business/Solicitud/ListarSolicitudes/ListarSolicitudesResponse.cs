using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.Solicitud.ListarSolicitudes
{
    public class ListarSolicitudesResponse : Result
    {
        public List<SolicitudResponse>? Solicitudes { get; set; }

        public ListarSolicitudesResponse() { }

        public ListarSolicitudesResponse(List<Entities.Solicitud> solicitudes)
        {
            Solicitudes = new();
            foreach (var solicitud in solicitudes)
            {
                Solicitudes.Add(new SolicitudResponse(solicitud));
            }
        }

        public class SolicitudResponse
        {
            public int IdSolicitud { get; set; }
            public int IdEstado { get; set; }
            public string? Estudiante { get; set; }
            public string? Estado { get; set; }

            public SolicitudResponse() { }

            public SolicitudResponse(Entities.Solicitud solicitud)
            {
                IdSolicitud = solicitud.IdSolicitud;
                IdEstado = solicitud.EstadoId;
                Estudiante = $"{solicitud.Estudiante?.Nombre} {solicitud.Estudiante?.Apellido}";
                Estado = solicitud.Estado?.Nombre;
            }
        }
    }
}
