using BlazingCheckers.Client.Repositories;
using BlazingCheckers.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingCheckers.Client.ViewModels
{
    public class GamesViewModel
    {
        private readonly ApiGamesRepository _repo;

        public GamesViewModel(ApiGamesRepository repo)
        {
            _repo = repo;
        }

        public async Task Initialize()
        {
            await LoadGames();
        }

        private List<GameDto> _games;
        public List<GameDto> Games => _games;

        private async Task LoadGames()
        {
            _games = (await _repo.GetActiveGames()).ToList();
        }
    }
}