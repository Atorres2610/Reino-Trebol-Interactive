using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReinoTrebol.Core.Entities
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [ForeignKey(nameof(Grimorio))]
        public int? GrimorioId { get; set; }

        [ForeignKey(nameof(AfinidadMagica))]
        public int AfinidadMagicaId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Identificacion { get; set; } = string.Empty;

        [Required]
        public int Edad { get; set; }

        #region Propiedaddes de navegacion
        public Grimorio? Grimorio { get; set; }
        public Solicitud? Solicitud { get; set; }
        public AfinidadMagica? AfinidadMagica { get; set; }
        #endregion
    }
}
