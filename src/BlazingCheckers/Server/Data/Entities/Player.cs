namespace BlazingCheckers.Server.Data.Entities
{
    public class Player : IEntity
    {
        public object PK => new { GameId, UserId };
        public int GameId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }

        public Game Game { get; set; }
        public PlayerStatus Status { get; set; }
        public User User { get; set; }
    }
}