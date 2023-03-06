using Microsoft.AspNetCore.Mvc;
using ReinoTrebol.Core.Business.Estado.ListarEstados;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstadoController : BaseController
    {
        private readonly IEstadoRepository estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            this.estadoRepository = estadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ListarEstados()
        {
            var estados = await estadoRepository.ListarEstados();
            return ResultResponse(new ListarEstadosResponse(estados));
        }
    }
}
