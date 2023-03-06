using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MyLibrary.Services.API
{
    public class APIClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public APIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            DeleteDefaultHeaders();
        }

        public enum HttpVerbs
        {
            GET, POST, PUT, DELETE, PATCH
        }

        public void AddDefaultHeaders(string key, string value)
        {
            httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public void AddDefaultHeadersAccept(MediaTypeWithQualityHeaderValue mediaTypeWithQualityHeaderValue)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(mediaTypeWithQualityHeaderValue);
        }

        public void AddToken(string token, string schema = "Bearer")
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, token);
        }

        public void DeleteDefaultHeaders()
        {
            httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<APIResponse<TResponse>> Call<TResponse, TRequest>(HttpVerbs httpVerbs, string url, bool withResponse = true,
            TRequest? requestParameters = default, IFormCollection? formsCollection = null)
        {
            HttpContent? content = null;

            if (requestParameters is not null || formsCollection is not null)
            {
                string? stringParameters = JsonSerializer.Serialize(requestParameters);

                if ((formsCollection is null || formsCollection.Count == 0) && httpVerbs != HttpVerbs.GET && httpVerbs != HttpVerbs.DELETE)
                {
                    content = BuildBody(stringParameters);
                }
                else if (formsCollection is not null && formsCollection.Count > 0)
                {
                    content = BuildFormData(formsCollection);
                }
                else if (!string.IsNullOrEmpty(stringParameters))
                {
                    url = $"{url}{BuildQuery(stringParameters)}";
                }
            }

            TResponse? response = default;
            string? responseMessageError = null;

            using HttpResponseMessage responseMessage = httpVerbs switch
            {
                HttpVerbs.GET => await httpClient.GetAsync(url),
                HttpVerbs.POST => await httpClient.PostAsync(url, content),
                HttpVerbs.PUT => await httpClient.PutAsync(url, content),
                HttpVerbs.DELETE => await httpClient.DeleteAsync(url),
                HttpVerbs.PATCH => await httpClient.PatchAsync(url, content),
                _ => throw new NotImplementedException()
            };

            if (responseMessage.IsSuccessStatusCode)
            {
                if (withResponse)
                {
                    var contentMessage = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonSerializer.Deserialize<TResponse>(contentMessage, jsonSerializerOptions);
                }
            }
            else
            {
                responseMessageError = await responseMessage.Content.ReadAsStringAsync();
            }

            return new APIResponse<TResponse>(responseMessage.StatusCode, response, !responseMessage.IsSuccessStatusCode, responseMessageError);
        }

        private static HttpContent? BuildBody(string? parameters = null)
        {
            return !string.IsNullOrEmpty(parameters) ? new StringContent(parameters, Encoding.UTF8, "application/json") : null;
        }

        private static HttpContent BuildFormData(IFormCollection? formCollection)
        {
            var multipartContent = new MultipartFormDataContent();

            if (formCollection is not null)
            {
                foreach (var form in formCollection)
                {
                    multipartContent.Add(new StringContent(form.Value!), form.Key);
                }

                foreach (var file in formCollection.Files)
                {
                    multipartContent.Add(new StreamContent(file.OpenReadStream()), file.Name, file.FileName);
                }
            }

            return multipartContent;
        }

        private static string BuildQuery(string parameters)
        {
            JsonObject? jObject = JsonSerializer.Deserialize<JsonObject>(parameters);
            Dictionary<string, string> dic = new();
            string uri = "?";
            IEnumerator<KeyValuePair<string, JsonNode?>>? keyValue = jObject?.GetEnumerator();

            bool isTrue = !string.IsNullOrWhiteSpace(parameters);
            while (isTrue)
            {
                if (keyValue?.Current.Key != null)
                {
                    if (!string.IsNullOrWhiteSpace(keyValue?.Current.Value!.ToString()))
                    {
                        dic.Add(keyValue.Current.Key, keyValue.Current.Value!.ToString());
                    }
                }
                isTrue = keyValue!.MoveNext();
            }

            foreach (KeyValuePair<string, string> item in dic)
            {
                if (item.Value.StartsWith("["))
                {
                    string[] strings = item.Value.Replace("[", "").Replace("]", "").Replace("\n  \"", "").Replace("\"", "").Replace("\n", "").Split(",");
                    foreach (string s in strings)
                    {
                        uri += $"{item.Key}={s.ToString().Trim()}&";
                    }
                }
                else
                {
                    string itemValue = item.Value == "&" ? "%26" : item.Value;
                    uri += $"{item.Key}={itemValue}&";
                }
            }
            if (uri != "?")
            {
                uri = uri.Remove(uri.LastIndexOf("&"));
            }

            return uri;
        }
    }
}
