using System;

namespace BlazingCheckers.Shared.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
}