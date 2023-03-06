using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReinoTrebol.Core.Business.Estudiante.ListarEstudiantesAsignados;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstudianteController : BaseController
    {
        private readonly IEstudianteRepository estudianteRepository;

        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ListarEstudiantesAsignados()
        {
            var estudiantes = await estudianteRepository.ListarEstudiantes(predicate: e => e.Grimorio != null,
                include: e => e.Include(x => x.Grimorio), false);
            ListarEstudiantesAsignadosResponse response = new(estudiantes);
            return ResultResponse(response);
        }
    }
}
