using BlazingCheckers.Shared.Entities;

namespace BlazingCheckers.Shared.Models
{
    public class GameStatusModel : GameStatus
    {
        public GameStatusModel() { }
        public GameStatusModel(GameStatus gs)
        {
            if (gs == null) return;

            Id = gs.Id;
            Status = gs.Status;
        }
    }
}
