using BlazingCheckers.Shared.Entities;

namespace BlazingCheckers.Shared.Models
{
    public class GameModel : Game
    {
        public new GameStatusModel Status { get; set; }

        public GameModel() { }
        public GameModel(Game g)
        {
            if (g == null) return;

            Id = g.Id;
            StatusId = g.StatusId;
            CreatedOn = g.CreatedOn;
            UpdatedOn = g.UpdatedOn;
            CompletedOn = g.CompletedOn;

            if (g.Status != null)
                Status = new GameStatusModel(g.Status);
        }
    }
}