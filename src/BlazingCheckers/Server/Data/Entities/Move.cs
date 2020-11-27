using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingCheckers.Server.Data.Entities
{
    public class Move : IEntity
    {
        public object PK => Id;

        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public int PieceId { get; set; }
        public int ToPosition { get; set; }
        public int MoveNumber { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
        public GamePiece Piece { get; set; }
        public Player Player { get; set; }

        public virtual ICollection<Capture> Captures { get; set; }
    }
}