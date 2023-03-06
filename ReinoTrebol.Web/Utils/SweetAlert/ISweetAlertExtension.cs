using CurrieTechnologies.Razor.SweetAlert2;

namespace ReinoTrebol.Web.Utils.SweetAlert
{
    public interface ISweetAlertExtension
    {
        Task<SweetAlertResult> SweetOptionsDefault(string? titulo, string? texto, bool error);
        Task<SweetAlertResult> SweetOptionsAnswer(string? titulo, string? texto);
    }
}
