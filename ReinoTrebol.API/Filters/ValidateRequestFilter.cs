using Microsoft.AspNetCore.Mvc.Filters;
using ReinoTrebol.API.Models;
using System.Net;
using System.Text;

namespace ReinoTrebol.API.Filters
{
    public class ValidateRequestFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(state => state.Value!.Errors.Select(x => x.ErrorMessage));
                if (errors.Any())
                {
                    string resultException = new ResultException<IEnumerable<string>>()
                    {
                        Code = StatusCodes.Status400BadRequest,
                        Message = "Se presentaron uno o más errores de validación.",
                        DataException = errors
                    }.ToString();

                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.HttpContext.Response.WriteAsync(resultException, Encoding.UTF8);
                }
            }
            else
            {
                await next();
            }
        }
    }
}
