using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReinoTrebol.Core.Entities
{
    public class Grimorio
    {
        public Grimorio()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        public int IdGrimorio { get; set; }

        [ForeignKey(nameof(Portada))]
        public int PortadaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public Portada? Portada { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
