using Microsoft.AspNetCore.Http;
using MyLibrary.Services.API;
using System.Net;

namespace ReinoTrebol.Core.Business.Solicitud.EnviarSolicitud
{
    public class EnviarSolicitudUseCase
    {
        private readonly EnviarSolicitudRequest request;
        private readonly Entities.AfinidadMagica? afinidadMagica;
        private readonly Entities.Estado estado;

        public Entities.Solicitud? SolicitudNueva { get; set; }

        public EnviarSolicitudUseCase(EnviarSolicitudRequest request, Entities.AfinidadMagica? afinidadMagica, Entities.Estado estado)
        {
            this.request = request;
            this.afinidadMagica = afinidadMagica;
            this.estado = estado;
        }

        public Result Execute()
        {
            var result = ValidarExistenciaAfinidadMagica();
            if (result.Code == StatusCodes.Status200OK)
            {
                CrearSolicitud();
            }
            return result;
        }

        private Result ValidarExistenciaAfinidadMagica()
        {
            if (afinidadMagica is null)
            {
                return new() { Code = StatusCodes.Status400BadRequest, Message = "La afinidad mágica indicada no existe." };
            }
            return new();
        }

        private void CrearSolicitud()
        {
            SolicitudNueva = new()
            {
                EstadoId = estado.IdEstado,
                Estudiante = new()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Edad = request.Edad,
                    AfinidadMagicaId = request.AfinidadMagicaId,
                    GrimorioId = null,
                    Identificacion = request.Identificacion
                }
            };
        }
    }
}
