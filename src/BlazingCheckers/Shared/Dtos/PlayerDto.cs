namespace BlazingCheckers.Shared.Dtos
{
    public class PlayerDto
    {
        public object PK { get; set; }
        public string Username { get; set; }
        public int GameId { get; set; }
        public GameDto Game { get; set; }
    }
}
