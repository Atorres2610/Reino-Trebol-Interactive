using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReinoTrebol.Infrastructure.Data;
using ReinoTrebol.Infrastructure.Repositories;
using ReinoTrebol.Infrastructure.Repositories.Interfaces;

namespace ReinoTrebol.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<ISolicitudRepository, SolicitudRepository>();
            services.AddScoped<IAfinidadMagicaRepository, AfinidadMagicaRepository>();
            services.AddScoped<IGrimorioRepository, GrimorioRepository>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            return services;
        }
    }
}
