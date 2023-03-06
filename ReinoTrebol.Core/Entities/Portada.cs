using System.ComponentModel.DataAnnotations;

namespace ReinoTrebol.Core.Entities
{
    public class Portada
    {
        [Key]
        public int IdPortada { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public Grimorio? Grimorio { get; set; }
    }
}
