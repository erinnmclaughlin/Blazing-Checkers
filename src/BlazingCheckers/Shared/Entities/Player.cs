namespace BlazingCheckers.Shared.Entities
{
    public class Player
    {
        public object Id => new { GameId, UserId };
        public int GameId { get; set; }
        public string UserId { get; set; }

        public int StatusId { get; set; }
    }
}