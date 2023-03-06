using Microsoft.AspNetCore.Http;
using MyLibrary.Services.API;
using System.Net;

namespace ReinoTrebol.Core.Business.Solicitud.ActualizarStatusSolicitud
{
    public class ActualizarStatusSolicitudUseCase
    {
        private readonly Entities.Solicitud? solicitud;
        private readonly Entities.Estado? estado;
        private readonly List<Entities.Grimorio> grimorios;

        public ActualizarStatusSolicitudUseCase(Entities.Solicitud? solicitud, Entities.Estado? estado, List<Entities.Grimorio> grimorios)
        {
            this.solicitud = solicitud;
            this.estado = estado;
            this.grimorios = grimorios;
        }

        public Result Execute()
        {
            Result result = ValidarSolicitud();
            if (result.Code == StatusCodes.Status200OK)
            {
                result = ValidarEstado();
                if (result.Code == StatusCodes.Status200OK)
                {
                    ActualizarEstado();
                    AsignarGrimorio();
                }
            }
            return result;
        }

        private Result ValidarEstado()
        {
            if (estado is null)
            {
                return new() { Code = StatusCodes.Status404NotFound, Message = "No se encontró el estado." };
            }
            return new();
        }

        private Result ValidarSolicitud()
        {
            if (solicitud is null)
            {
                return new() { Code = StatusCodes.Status404NotFound, Message = "No se encontró la solicitud." };
            }
            return new();
        }

        private void ActualizarEstado()
        {
            solicitud!.EstadoId = estado!.IdEstado;
        }

        private void AsignarGrimorio()
        {
            if (solicitud!.Estudiante is not null && estado!.IdEstado == (int)Entities.Estado.Estados.Aprobada)
            {
                Random random = new();
                int idGrimorio = grimorios.OrderBy(x => random.Next()).First().IdGrimorio;
                solicitud!.Estudiante.GrimorioId = idGrimorio;
            }
        }
    }
}
