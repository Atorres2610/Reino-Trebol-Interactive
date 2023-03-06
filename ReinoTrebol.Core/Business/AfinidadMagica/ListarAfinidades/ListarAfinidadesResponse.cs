using MyLibrary.Services.API;

namespace ReinoTrebol.Core.Business.AfinidadMagica.ListarAfinidades
{
    public class ListarAfinidadesResponse : Result
    {
        public List<AfinidadResponse>? AfinidadesMagicas { get; set; }

        public ListarAfinidadesResponse(List<Entities.AfinidadMagica> afinidades)
        {
            AfinidadesMagicas = new();
            afinidades.ForEach(x => AfinidadesMagicas.Add(new AfinidadResponse(x.IdAfinidadMagica, x.Nombre)));
        }

        public ListarAfinidadesResponse() { }

        public class AfinidadResponse
        {
            public AfinidadResponse() { }

            public AfinidadResponse(int idAfinidadMagica, string nombre)
            {
                IdAfinidadMagica = idAfinidadMagica;
                Nombre = nombre;
            }

            public int? IdAfinidadMagica { get; set; }
            public string? Nombre { get; set; }
        }
    }
}
