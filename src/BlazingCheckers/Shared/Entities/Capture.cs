namespace BlazingCheckers.Shared.Entities
{
    public class Capture
    {
        public object Id => new { MoveId, PieceId };
        public int MoveId { get; set; }
        public int PieceId { get; set; }
    }
}