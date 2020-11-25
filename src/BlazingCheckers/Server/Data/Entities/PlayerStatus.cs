namespace BlazingCheckers.Server.Data.Entities
{
    // Current, Waiting, Winner, Loser, Draw
    public class PlayerStatus : IEntity
    {
        public object PK => Id;

        public int Id { get; set; }
        public string Status { get; set; }
    }
}