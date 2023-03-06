using Microsoft.AspNetCore.Mvc;
using MyLibrary.Services.API;

namespace ReinoTrebol.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult ResultResponse(Result? result = null)
        {
            result ??= new Result();
            return StatusCode(result.Code, result);
        }
    }
}
