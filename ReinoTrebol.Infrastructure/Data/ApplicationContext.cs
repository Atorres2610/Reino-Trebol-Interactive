using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReinoTrebol.Core.Entities;

namespace ReinoTrebol.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AfinidadMagica> AfinidadesMagicas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grimorio> Grimorios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Portada> Portadas { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AfinidadMagica>().ToTable(name: nameof(AfinidadMagica))
                .HasKey(x => x.IdAfinidadMagica).HasName("PK_AfinidadMagica").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            modelBuilder.Entity<Estudiante>().ToTable(name: nameof(Estudiante))
                .HasKey(x => x.IdEstudiante).HasName("PK_Estudiante").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            modelBuilder.Entity<Grimorio>().ToTable(name: nameof(Grimorio))
                .HasKey(x => x.IdGrimorio).HasName("PK_Grimorio").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            modelBuilder.Entity<Solicitud>().ToTable(name: nameof(Solicitud))
                .HasKey(x => x.IdSolicitud).HasName("PK_Solicitud").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            modelBuilder.Entity<Portada>().ToTable(name: nameof(Portada))
                .HasKey(x => x.IdPortada).HasName("PK_Portada").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            modelBuilder.Entity<Estado>().ToTable(name: nameof(Estado))
                .HasKey(x => x.IdEstado).HasName("PK_Estado").HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
        }
    }
}
