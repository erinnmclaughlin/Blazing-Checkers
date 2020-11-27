using BlazingCheckers.Client.Repositories;
using BlazingCheckers.Shared.Dtos;
using System.Threading.Tasks;

namespace BlazingCheckers.Client.ViewModels
{
    public class GameViewModel
    {
        private readonly ApiGamesRepository _repo;
        private int _gameId;

        public GameViewModel(ApiGamesRepository repo)
        {
            _repo = repo;
        }

        public async Task Initialize(int gameId)
        {
            _gameId = gameId;
            await LoadGame();
        }

        private GameDto _game;
        public GameDto Game => _game;

        public async Task LoadGame()
        {
            _game = await _repo.GetById(_gameId);
        }
    }
}
