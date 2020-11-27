using System.Collections.Generic;

namespace BlazingCheckers.Server.Data.Entities
{
    public class GamePiece : IEntity
    {
        public object PK => Id;

        public int Id { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
        public bool IsKinged { get; set; }
        public int StartPosition { get; set; }

        public Game Game { get; set; }        
        public Player Player { get; set; }

        public virtual ICollection<Move> Moves { get; set; }
    }
}