using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReinoTrebol.API.Filters;
using ReinoTrebol.Core.Business.Solicitud.ActualizarSolicitud;
using ReinoTrebol.Core.Business.Solicitud.ActualizarStatusSolicitud;
using ReinoTrebol.Core.Business.Solicitud.EnviarSolicitud;
using ReinoTrebol.Core.Business.Solicitud.ListarSolicitudes;
using ReinoTrebol.Core.Business.Solicitud.ObtenerSolicitud;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SolicitudController : BaseController
    {
        private readonly ISolicitudRepository solicitudRepository;
        private readonly IBaseRepository baseRepository;
        private readonly IAfinidadMagicaRepository afinidadMagicaRepository;
        private readonly IEstadoRepository estadoRepository;
        private readonly IGrimorioRepository grimorioRepository;

        public SolicitudController(ISolicitudRepository solicitudRepository, IBaseRepository baseRepository,
            IAfinidadMagicaRepository afinidadMagicaRepository, IEstadoRepository estadoRepository, IGrimorioRepository grimorioRepository)
        {
            this.solicitudRepository = solicitudRepository;
            this.baseRepository = baseRepository;
            this.afinidadMagicaRepository = afinidadMagicaRepository;
            this.estadoRepository = estadoRepository;
            this.grimorioRepository = grimorioRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ListarSolicitudes()
        {
            var solicitudes = await solicitudRepository.ListarSolicitudes(include: s => s.Include(x => x.Estado).Include(x => x.Estudiante), false);
            return ResultResponse(new ListarSolicitudesResponse(solicitudes));
        }

        [HttpGet("{idSolicitud}")]
        public async Task<ActionResult> ObtenerSolicitud(int idSolicitud)
        {
            var solicitud = await solicitudRepository.ObtenerSolicitud(idSolicitud, include: s => s.Include(x => x.Estudiante), false);
            if (solicitud is null)
            {
                return ResultResponse(new MyLibrary.Services.API.Result() { Code = StatusCodes.Status404NotFound, Message = "No se encontró la solicitud." });
            }
            return ResultResponse(new ObtenerSolicitudResponse(solicitud));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateRequestFilter))]
        public async Task<ActionResult> EnviarSolicitud([FromBody] EnviarSolicitudRequest request)
        {
            var estadoSolicitud = await estadoRepository.ObtenerEstado((int)Estado.Estados.Enviada);
            var afinidadMagica = await afinidadMagicaRepository.ObtenerAfinidadMagica(request.AfinidadMagicaId);

            EnviarSolicitudUseCase useCase = new(request, afinidadMagica, estadoSolicitud!);
            var result = useCase.Execute();

            if (result.Code == StatusCodes.Status200OK)
            {
                await solicitudRepository.GuardarSolicitud(useCase.SolicitudNueva!);
                await baseRepository.SaveChangesAsync();
            }

            return ResultResponse(result);
        }

        [HttpPut("{idSolicitud}")]
        [ServiceFilter(typeof(ValidateRequestFilter))]
        public async Task<ActionResult> ActualizarSolicitud(int idSolicitud, [FromBody] ActualizarSolicitudRequest request)
        {
            var solicitud = await solicitudRepository.ObtenerSolicitud(idSolicitud,
                include: source => source.Include(s => s.Estudiante), false);
            var afinidadMagica = await afinidadMagicaRepository.ObtenerAfinidadMagica(request.AfinidadMagicaId);

            ActualizarSolicitudUseCase useCase = new(request, solicitud, afinidadMagica);
            var result = useCase.Execute();

            if (result.Code == StatusCodes.Status200OK)
            {
                await baseRepository.SaveChangesAsync();
            }

            return ResultResponse(result);
        }

        [HttpPatch("{idSolicitud}")]
        [ServiceFilter(typeof(ValidateRequestFilter))]
        public async Task<ActionResult> ActualizarStatusSolicitud(int idSolicitud, [FromBody] ActualizarStatusSolicitudRequest request)
        {
            var solicitud = await solicitudRepository.ObtenerSolicitud(idSolicitud, include: s => s.Include(x => x.Estudiante), false);
            var estado = await estadoRepository.ObtenerEstado(request.IdEstado);
            var grimorios = await grimorioRepository.ListarGrimorios();

            ActualizarStatusSolicitudUseCase useCase = new(solicitud, estado, grimorios);
            var result = useCase.Execute();

            if (result.Code == StatusCodes.Status200OK)
            {
                await baseRepository.SaveChangesAsync();
            }

            return ResultResponse(result);
        }

        [HttpDelete("{idSolicitud}")]
        public async Task<ActionResult> EliminarSolicitud(int idSolicitud)
        {
            var solicitud = await solicitudRepository.ObtenerSolicitud(idSolicitud);
            if (solicitud is not null)
            {
                solicitudRepository.EliminarSolicitud(solicitud);
                await baseRepository.SaveChangesAsync();
            }
            return ResultResponse();
        }
    }
}
