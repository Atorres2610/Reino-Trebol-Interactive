using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.Solicitud.ObtenerSolicitud
{
    public class ObtenerSolicitudResponse : Result
    {
        public SolicitudResponse? Solicitud { get; set; }

        public ObtenerSolicitudResponse(Entities.Solicitud solicitud)
        {
            Solicitud = new(solicitud);
        }

        public ObtenerSolicitudResponse() { }

        public class SolicitudResponse
        {
            public int IdSolicitud { get; set; }
            public string NombreEstudiante { get; set; } = string.Empty;
            public string ApellidoEstudiante { get; set; } = string.Empty;
            public int Edad { get; set; }
            public string Identificacion { get; set; } = string.Empty;
            public int IdAfinidadMagica { get; set; }

            public SolicitudResponse(Entities.Solicitud solicitud)
            {
                IdSolicitud = solicitud.IdSolicitud;
                NombreEstudiante = solicitud.Estudiante.Nombre;
                ApellidoEstudiante = solicitud.Estudiante.Apellido;
                Edad = solicitud.Estudiante.Edad;
                Identificacion = solicitud.Estudiante.Identificacion;
                IdAfinidadMagica = solicitud.Estudiante.AfinidadMagicaId;
            }

            public SolicitudResponse() { }
        }
    }
}
