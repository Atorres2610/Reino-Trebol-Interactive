using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.Estado.ListarEstados
{
    public class ListarEstadosResponse : Result
    {
        public List<EstadoResponse>? Estados { get; set; }

        public ListarEstadosResponse(List<Entities.Estado> estados)
        {
            Estados = new();
            estados.ForEach(e => Estados.Add(new EstadoResponse(e.IdEstado, e.Nombre)));
        }

        public ListarEstadosResponse() { }
    }

    public class EstadoResponse
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public EstadoResponse(int idEstado, string nombre)
        {
            IdEstado = idEstado;
            Nombre = nombre;
        }

        public EstadoResponse() { }
    }
}
