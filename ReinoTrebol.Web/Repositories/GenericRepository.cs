using MyLibrary.Services.API;

namespace ReinoTrebol.Web.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly APIClient client;

        public GenericRepository(APIClient client)
        {
            this.client = client;
        }

        public async Task<APIResponse<TResponse>> Delete<TResponse>(string url, bool withResponse)
        {
            return await client.Call<TResponse, object>(APIClient.HttpVerbs.DELETE, url, withResponse);
        }

        public async Task<APIResponse<TResponse>> Get<TResponse>(string url, bool withResponse)
        {
            return await client.Call<TResponse, object>(APIClient.HttpVerbs.GET, url, withResponse);
        }

        public async Task<APIResponse<TResponse>> Patch<TResponse>(string url, bool withResponse)
        {
            return await client.Call<TResponse, object>(APIClient.HttpVerbs.PATCH, url, withResponse);
        }

        public async Task<APIResponse<TResponse>> Post<TResponse, TRequest>(string url, TRequest request, bool withResponse)
        {
            return await client.Call<TResponse, TRequest>(APIClient.HttpVerbs.POST, url, withResponse, request);
        }

        public async Task<APIResponse<TResponse>> Put<TResponse, TRequest>(string url, TRequest request, bool withResponse)
        {
            return await client.Call<TResponse, TRequest>(APIClient.HttpVerbs.PUT, url, withResponse, request);
        }

        public async Task<APIResponse<TResponse>> Post<TResponse>(string url, bool withResponse)
        {
            return await client.Call<TResponse, object>(APIClient.HttpVerbs.POST, url, withResponse);
        }

        public async Task<APIResponse<TResponse>> Put<TResponse>(string url, bool withResponse)
        {
            return await client.Call<TResponse, object>(APIClient.HttpVerbs.PUT, url, withResponse);
        }

        public async Task<APIResponse<TResponse>> Patch<TResponse, TRequest>(string url, TRequest request, bool withResponse)
        {
            return await client.Call<TResponse, TRequest>(APIClient.HttpVerbs.PATCH, url, withResponse, request);
        }
    }
}
