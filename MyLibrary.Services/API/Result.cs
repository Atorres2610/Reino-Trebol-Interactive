using Microsoft.AspNetCore.Http;

namespace MyLibrary.Services.API
{
    public class Result
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;

        public Result()
        {
            Code = StatusCodes.Status200OK;
        }
    }
}
