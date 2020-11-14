namespace BlazingCheckers.Shared.Entities
{
    public class GamePiece
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
        public bool IsKinged { get; set; }
        public int StartPosition { get; set; }
    }
}