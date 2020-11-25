using System;
using System.Collections.Generic;

namespace BlazingCheckers.Shared.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public virtual ICollection<PlayerDto> Players { get; set; }
    }
}
