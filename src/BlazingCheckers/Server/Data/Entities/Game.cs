using System;
using System.Collections.Generic;

namespace BlazingCheckers.Server.Data.Entities
{
    public class Game : IEntity
    {
        public object PK => Id;

        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }

        public GameStatus Status { get; set; }

        public virtual ICollection<Move> Moves { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<GamePiece> Pieces { get; set; }
    }
}