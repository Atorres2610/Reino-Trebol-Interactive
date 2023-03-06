using System.ComponentModel.DataAnnotations;

namespace ReinoTrebol.Core.Entities
{
    public class Estado
    {
        public enum Estados
        {
            Enviada = 1,
            Aprobada = 2,
            Rechazada = 3
        }

        public Estado()
        {
            Solicitudes = new HashSet<Solicitud>();
        }

        [Key]
        public int IdEstado { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        public ICollection<Solicitud> Solicitudes { get; set; }
    }
}
