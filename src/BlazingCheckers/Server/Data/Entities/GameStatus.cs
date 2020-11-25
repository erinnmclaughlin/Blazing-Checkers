namespace BlazingCheckers.Server.Data.Entities
{
    // Active, Completed, TimedOut
    public class GameStatus : IEntity
    {
        public object PK => Id;

        public int Id { get; set; }
        public string Status { get; set; }
    }
}
