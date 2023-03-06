using System.ComponentModel.DataAnnotations;

namespace ReinoTrebol.Core.Entities
{
    public class AfinidadMagica
    {
        [Key]
        public int IdAfinidadMagica { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
