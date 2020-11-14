namespace BlazingCheckers.Shared.Entities
{
    public class Move
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public int PieceId { get; set; }
        public int ToPosition { get; set; }
        public int MoveNumber { get; set; }
    }
}