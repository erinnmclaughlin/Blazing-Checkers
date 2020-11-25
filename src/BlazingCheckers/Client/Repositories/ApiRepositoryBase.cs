using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingCheckers.Client.Repositories
{
    public abstract class ApiRepositoryBase<T>
    {
        private readonly string _controllerName;
        protected readonly HttpClient _httpClient;

        public ApiRepositoryBase(HttpClient httpClient, string controllerName)
        {
            _httpClient = httpClient;
            _controllerName = controllerName;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"api/{_controllerName}");
        }

        public async Task<T> GetById(object id)
        {
            return await _httpClient.GetFromJsonAsync<T>($"api/{_controllerName}/{id}");
        }
    }
}
