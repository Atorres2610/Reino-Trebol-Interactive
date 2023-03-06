using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.Grimorio.ListarAsignaciones
{
    public class ListarAsignacionesResponse : Result
    {
        public List<AsignacionResponse>? Asignaciones { get; set; }

        public ListarAsignacionesResponse(List<Entities.Grimorio> grimorios)
        {
            Asignaciones = new();
            grimorios.ForEach(x => Asignaciones.Add(new AsignacionResponse(x.Nombre, x.Estudiantes.Count)));
        }

        public ListarAsignacionesResponse() { }
    }

    public class AsignacionResponse
    {
        public string Grimorio { get; set; } = null!;
        public int EstudiantesAsignados { get; set; }

        public AsignacionResponse(string grimorio, int estudiantesAsignados)
        {
            Grimorio = grimorio;
            EstudiantesAsignados = estudiantesAsignados;
        }

        public AsignacionResponse() { }
    }
}
