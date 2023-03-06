using System.ComponentModel.DataAnnotations;

namespace ReinoTrebol.Core.Business.Solicitud.ActualizarSolicitud
{
    public class ActualizarSolicitudRequest
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo {0} solo permite letras del alfabeto.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo {0} solo permite letras del alfabeto.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 99, ErrorMessage = "Debe ingresar un número entero mayor que {1} y menor que {2}.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "El campo {0} solo permite letras y números.")]
        public string Identificacion { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser igual o mayor a {1}")]
        public int AfinidadMagicaId { get; set; }
    }
}
