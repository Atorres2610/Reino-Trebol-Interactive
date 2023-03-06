using MyLibrary.Services.API;

namespace ReinoTrebol.Web.Repositories
{
    public interface IGenericRepository
    {
        Task<APIResponse<TResponse>> Get<TResponse>(string url, bool withResponse);
        Task<APIResponse<TResponse>> Post<TResponse>(string url, bool withResponse);
        Task<APIResponse<TResponse>> Post<TResponse, TRequest>(string url, TRequest request, bool withResponse);
        Task<APIResponse<TResponse>> Put<TResponse, TRequest>(string url, TRequest request, bool withResponse);
        Task<APIResponse<TResponse>> Put<TResponse>(string url, bool withResponse);
        Task<APIResponse<TResponse>> Patch<TResponse>(string url, bool withResponse);
        Task<APIResponse<TResponse>> Patch<TResponse, TRequest>(string url, TRequest request, bool withResponse);
        Task<APIResponse<TResponse>> Delete<TResponse>(string url, bool withResponse);
    }
}
