using MyLibrary.Services.API;
using System.Text.Json;

namespace ReinoTrebol.API.Models
{
    public class ResultException<T> : Result
    {
        public T? DataException { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
