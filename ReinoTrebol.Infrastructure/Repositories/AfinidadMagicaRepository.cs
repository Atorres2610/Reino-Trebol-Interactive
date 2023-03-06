using Microsoft.EntityFrameworkCore;
using ReinoTrebol.Core.Entities;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.Infrastructure.Repositories
{
    public class AfinidadMagicaRepository : IAfinidadMagicaRepository
    {
        private readonly ApplicationContext context;

        public AfinidadMagicaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<AfinidadMagica>> ListarAfinidadesMagicas()
        {
            return await context.AfinidadesMagicas.ToListAsync();
        }

        public async Task<AfinidadMagica?> ObtenerAfinidadMagica(int idAfinidadMagica, bool disabledTraking = true)
        {
            IQueryable<AfinidadMagica> query = context.AfinidadesMagicas;

            if (disabledTraking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x => x.IdAfinidadMagica == idAfinidadMagica);
        }
    }
}
