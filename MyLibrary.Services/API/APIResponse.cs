using System.Net;

namespace MyLibrary.Services.API
{
    public class APIResponse<T>
    {
        private readonly string? _httpResponseMessage;
        private readonly HttpStatusCode _httpStatusCode;

        public APIResponse(HttpStatusCode httpStatusCode, T? data, bool error, string? httpResponseMessage)
        {
            _httpStatusCode = httpStatusCode;
            Data = data;
            Error = error;
            _httpResponseMessage = httpResponseMessage;
        }

        public T? Data { get; set; }
        public bool Error { get; set; }

        public string? GetErrorMessage()
        {
            if (!Error)
            {
                return null;
            }

            return _httpStatusCode switch
            {
                HttpStatusCode.BadRequest => _httpResponseMessage,
                HttpStatusCode.Unauthorized => "Tienes que loguearte para hacer esta operación.",
                HttpStatusCode.Forbidden => "No tienes permiso para hacer esta operación.",
                HttpStatusCode.NotFound => "Recurso no encontrado.",
                _ => _httpResponseMessage
            };
        }
    }
}
