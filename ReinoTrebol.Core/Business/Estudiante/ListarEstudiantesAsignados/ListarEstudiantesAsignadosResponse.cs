using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.Estudiante.ListarEstudiantesAsignados
{
    public class ListarEstudiantesAsignadosResponse : Result
    {
        public List<EstuadianteAsignadoResponse>? EstudiantesAsignados { get; set; }

        public ListarEstudiantesAsignadosResponse(List<Entities.Estudiante> estudiantes)
        {
            EstudiantesAsignados = new();
            estudiantes.ForEach(x => EstudiantesAsignados.Add(new EstuadianteAsignadoResponse(x.Nombre, x.Apellido, x.Grimorio!.Nombre)));
        }

        public ListarEstudiantesAsignadosResponse() { }
    }

    public class EstuadianteAsignadoResponse
    {
        public string Estudiante { get; set; } = string.Empty;
        public string Grimorio { get; set; } = string.Empty;

        public EstuadianteAsignadoResponse(string nombre, string apellido, string grimorio)
        {
            Estudiante = $"{nombre} {apellido}";
            Grimorio = grimorio;
        }

        public EstuadianteAsignadoResponse() { }
    }
}
