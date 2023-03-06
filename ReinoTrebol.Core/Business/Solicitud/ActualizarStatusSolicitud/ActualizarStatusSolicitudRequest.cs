using System.ComponentModel.DataAnnotations;

namespace ReinoTrebol.Core.Business.Solicitud.ActualizarStatusSolicitud
{
    public class ActualizarStatusSolicitudRequest
    {
        [Required(ErrorMessage = "El campo {Estado} es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser mayor o igual a {1}")]
        public int IdEstado { get; set; }
    }
}
