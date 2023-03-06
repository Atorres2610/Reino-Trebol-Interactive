using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReinoTrebol.Core.Business.Grimorio.ListarAsignaciones;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GrimorioController : BaseController
    {
        private readonly IGrimorioRepository grimorioRepository;

        public GrimorioController(IGrimorioRepository grimorioRepository)
        {
            this.grimorioRepository = grimorioRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ListarAsignaciones()
        {
            var grimorios = await grimorioRepository.ListarGrimorios(null, include: g => g.Include(x => x.Estudiantes), false);
            ListarAsignacionesResponse response = new(grimorios);
            return ResultResponse(response);
        }
    }
}
