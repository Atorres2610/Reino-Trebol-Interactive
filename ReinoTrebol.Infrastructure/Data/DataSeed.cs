using ReinoTrebol.Core.Entities;

namespace ReinoTrebol.Infrastructure.Data
{
    public class DataSeed
    {
        private readonly ApplicationContext context;

        public DataSeed(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();
            await CheckAfinidadMagica();
            await CheckPortada();
            await CheckGrimorio();
            await CheckEstados();
        }

        private async Task CheckEstados()
        {
            if (!context.Estados.Any())
            {
                List<Estado> lstEstados = new()
                {
                    new Estado { Nombre = "Enviada"},
                    new Estado { Nombre = "Aprobada"},
                    new Estado { Nombre = "Rechazada"}
                };

                context.Estados.AddRange(lstEstados);
                await context.SaveChangesAsync();
            }
        }

        private async Task CheckAfinidadMagica()
        {
            if (!context.AfinidadesMagicas.Any())
            {
                List<AfinidadMagica> lstAfinidadMagica = new()
                {
                    new AfinidadMagica { Nombre = "Oscuridad"},
                    new AfinidadMagica { Nombre = "Luz"},
                    new AfinidadMagica { Nombre = "Fuego"},
                    new AfinidadMagica { Nombre = "Agua"},
                    new AfinidadMagica { Nombre = "Viento"},
                    new AfinidadMagica { Nombre = "Tierra"}
                };

                context.AfinidadesMagicas.AddRange(lstAfinidadMagica);
                await context.SaveChangesAsync();
            }
        }

        private async Task CheckPortada()
        {
            if (!context.Portadas.Any())
            {
                List<Portada> lstTrebol = new()
                {
                    new Portada { Nombre = "Trébol de 1 hoja"},
                    new Portada { Nombre = "Trébol de 2 hojas"},
                    new Portada { Nombre = "Trébol de 3 hojas"},
                    new Portada { Nombre = "Trébol de 4 hojas"},
                    new Portada { Nombre = "Trébol de 5 hojas"}
                };

                context.Portadas.AddRange(lstTrebol);
                await context.SaveChangesAsync();
            }
        }

        private async Task CheckGrimorio()
        {
            if (!context.Grimorios.Any() && context.Portadas.Any())
            {
                List<Grimorio> lstGrimorio = new()
                {
                    new Grimorio { Nombre = "Sinceridad", PortadaId = 1 },
                    new Grimorio { Nombre = "Esperanza", PortadaId = 2 },
                    new Grimorio { Nombre = "Amor", PortadaId = 3},
                    new Grimorio { Nombre = "Buena Fortuna", PortadaId = 4},
                    new Grimorio { Nombre = "Desesperación", PortadaId = 5}
                };

                context.Grimorios.AddRange(lstGrimorio);
                await context.SaveChangesAsync();
            }
        }
    }
}
