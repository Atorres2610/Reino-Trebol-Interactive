using ReinoTrebol.Core.Entities;

namespace ReinoTrebol.Infrastructure.Repositories.Interfaces
{
    public interface IAfinidadMagicaRepository
    {
        Task<List<AfinidadMagica>> ListarAfinidadesMagicas();
        Task<AfinidadMagica?> ObtenerAfinidadMagica(int idAfinidadMagica, bool disabledTraking = true);
    }
}
