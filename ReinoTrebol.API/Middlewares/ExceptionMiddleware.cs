using ReinoTrebol.API.Models;
using System.Net;
using System.Text;

namespace ReinoTrebol.API.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment hostEnvironment;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError("Ocurrió un error inesperado: {Message} - {StackTrace}", ex.Message, ex.StackTrace);

                string resultExpection = new ResultException<string>()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Message = "Ocurrió un error inesperado.",
                    DataException = $"{(hostEnvironment.IsDevelopment() ? ex.Message : "Debe contactarse con el Rey Mago.")}"
                }.ToString();

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(resultExpection, Encoding.UTF8);
            }
        }
    }
}
