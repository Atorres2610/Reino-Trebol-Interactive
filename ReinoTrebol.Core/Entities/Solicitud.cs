using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReinoTrebol.Core.Entities
{
    public class Solicitud
    {
        [Key]
        public int IdSolicitud { get; set; }

        [Required]
        [ForeignKey(nameof(Estado))]
        public int EstadoId { get; set; }

        [ForeignKey(nameof(Estudiante))]
        public int EstudianteId { get; set; }

        public Estudiante Estudiante { get; set; } = null!;
        public Estado? Estado { get; set; }

        public void AprobarSolicitud()
        {
            EstadoId = (int)Estado.Estados.Aprobada;
        }

        public void RechazarSolicitud()
        {
            EstadoId = (int)Estado.Estados.Rechazada;
        }
    }
}
