using Microsoft.AspNetCore.Http;
using MyLibrary.Services.API;
using System.Net;

namespace ReinoTrebol.Core.Business.Solicitud.ActualizarSolicitud
{
    public class ActualizarSolicitudUseCase
    {
        private readonly ActualizarSolicitudRequest request;
        private readonly Entities.Solicitud? solicitud;
        private readonly Entities.AfinidadMagica? afinidadMagica;

        public ActualizarSolicitudUseCase(ActualizarSolicitudRequest request, Entities.Solicitud? solicitud, Entities.AfinidadMagica? afinidadMagica)
        {
            this.request = request;
            this.solicitud = solicitud;
            this.afinidadMagica = afinidadMagica;
        }

        public Result Execute()
        {
            var result = ValidarExistenciaSolicitud();
            if (result.Code == StatusCodes.Status200OK)
            {
                result = ValidarExistenciaAfinidadMagica();
                if (result.Code == StatusCodes.Status200OK)
                {
                    ActualizarSolicitud();
                }
            }

            return result;
        }

        private Result ValidarExistenciaSolicitud()
        {
            if (solicitud is null)
            {
                return new() { Code = StatusCodes.Status404NotFound, Message = "No se encontró la solicitud solicitada." };
            }
            return new();
        }

        private Result ValidarExistenciaAfinidadMagica()
        {
            if (afinidadMagica is null)
            {
                return new() { Code = StatusCodes.Status400BadRequest, Message = "La afinidad mágica indicada no existe." };
            }
            return new();
        }

        private void ActualizarSolicitud()
        {
            if (solicitud!.Estudiante is not null)
            {
                solicitud.Estudiante.Edad = request.Edad;
                solicitud.Estudiante.AfinidadMagicaId = request.AfinidadMagicaId;
                solicitud.Estudiante.Apellido = request.Apellido;
                solicitud.Estudiante.Nombre = request.Nombre;
                solicitud.Estudiante.Identificacion = request.Identificacion;
            }
        }
    }
}
