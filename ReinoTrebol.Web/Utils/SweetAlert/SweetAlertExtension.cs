using CurrieTechnologies.Razor.SweetAlert2;

namespace ReinoTrebol.Web.Utils.SweetAlert
{
    public class SweetAlertExtension : ISweetAlertExtension
    {
        private readonly SweetAlertService sweetAlertService;

        public SweetAlertExtension(SweetAlertService sweetAlertService)
        {
            this.sweetAlertService = sweetAlertService;
        }

        public async Task<SweetAlertResult> SweetOptionsAnswer(string? titulo, string? texto)
        {
            return await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = titulo,
                Text = texto,
                Icon = SweetAlertIcon.Question,
                HeightAuto = false,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Sí"
            });
        }

        public async Task<SweetAlertResult> SweetOptionsDefault(string? titulo, string? texto, bool error)
        {
            return await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = titulo,
                Text = texto,
                Icon = error ? SweetAlertIcon.Error : SweetAlertIcon.Success,
                HeightAuto = false
            });
        }
    }
}
