using Microsoft.AspNetCore.Mvc;
using ReinoTrebol.Core.Business.AfinidadMagica.ListarAfinidades;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AfinidadMagicaController : BaseController
    {
        private readonly IAfinidadMagicaRepository afinidadMagicaRepository;

        public AfinidadMagicaController(IAfinidadMagicaRepository afinidadMagicaRepository)
        {
            this.afinidadMagicaRepository = afinidadMagicaRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ListarAfinidades()
        {
            var afinidades = await afinidadMagicaRepository.ListarAfinidadesMagicas();
            return ResultResponse(new ListarAfinidadesResponse(afinidades));
        }
    }
}
