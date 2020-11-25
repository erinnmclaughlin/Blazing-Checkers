using BlazingCheckers.Shared.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingCheckers.Client.Repositories
{
    public class ApiGamesRepository : ApiRepositoryBase<GameDto>
    {
        public ApiGamesRepository(HttpClient httpClient) : base(httpClient, "users/current/games") { }

        public async Task<IEnumerable<GameDto>> GetActiveGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GameDto>>("api/users/current/games/active");
        }

        public async Task<IEnumerable<GameDto>> GetCompletedGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GameDto>>("api/users/current/games/completed");
        }
    }
}