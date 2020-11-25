using BlazingCheckers.Server.Data.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace BlazingCheckers.Server.Data
{
    public class BlazingCheckersContext : ApiAuthorizationDbContext<User>
    {
        public BlazingCheckersContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Capture>().HasKey(e => new { e.MoveId, e.PieceId });
            builder.Entity<Capture>().HasOne(e => e.Move).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<GamePiece>().HasOne(e => e.Player).WithMany().HasForeignKey(e => new { e.GameId, e.UserId });
            builder.Entity<Move>().HasOne(e => e.Game).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Move>().HasOne(e => e.Player).WithMany().HasForeignKey(e => new { e.GameId, e.UserId });
            builder.Entity<Player>().HasKey(e => new { e.GameId, e.UserId });

            builder.Entity<GameStatus>().HasData(new List<GameStatus>
            {
                new GameStatus { Id = 1, Status = "Pending" },
                new GameStatus { Id = 2, Status = "Active" },
                new GameStatus { Id = 3, Status = "Completed" },
                new GameStatus { Id = 4, Status = "Timed Out"}
            });

            builder.Entity<PlayerStatus>().HasData(new List<PlayerStatus>
            {
                new PlayerStatus { Id = 1, Status = "Current" },
                new PlayerStatus { Id = 2, Status = "Waiting" },
                new PlayerStatus { Id = 3, Status = "Winner" },
                new PlayerStatus { Id = 4, Status = "Loser" },
                new PlayerStatus { Id = 5, Status = "Draw" }
            });

            builder.Entity<User>().HasData(new List<User>
            {
                new User
                {
                    Id = "c51a5105-1bc9-44c1-ac95-aaad7b313f44",
                    UserName = "Player1@BlazingCheckers.com",
                    NormalizedUserName = "PLAYER1@BLAZINGCHECKERS.COM",
                    Email = "Player1@BlazingCheckers.com",
                    NormalizedEmail = "PLAYER1@BLAZINGCHECKERS.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEASu2xsK27f3SmwBGGUjuIoskicZ41AG3LwS9b+xNLrb1hS6LDjW0AyjTMkEaJREEQ==",
                    SecurityStamp = "TLNV3R47YSOFDEME7LUINVHZF5TXD77C",
                    ConcurrencyStamp = "1d5dff62-fae8-4315-89bf-e71e6e884a09"
                },
                new User
                {
                    Id = "accdf374-a78f-4664-bc8d-0b8a72cb0a6d",
                    UserName = "Player2@BlazingCheckers.com",
                    NormalizedUserName = "PLAYER2@BLAZINGCHECKERS.COM",
                    Email =  "Player2@BlazingCheckers.com",
                    NormalizedEmail = "PLAYER2@BLAZINGCHECKERS.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEBSVnKR+DG2RNcLAf3NbXK/g5S4hLirRg3MidXOmfo59uR+7492+hi6qNVBNqNSZrA==",
                    SecurityStamp = "AQAAAAEAACcQAAAAEBSVnKR+DG2RNcLAf3NbXK/g5S4hLirRg3MidXOmfo59uR+7492+hi6qNVBNqNSZrA==",
                    ConcurrencyStamp = "53a55fe9-743b-49c1-bd54-f4ef57d83cca"
                }
            });

            builder.Entity<Game>().HasData(new List<Game>
            {
                new Game { Id = 1, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 2 },
                //new Game { Id = 2, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 2 },
                //new Game { Id = 3, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
                //new Game { Id = 4, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
                //new Game { Id = 5, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
                //new Game { Id = 6, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 4 }
            });

            builder.Entity<Player>().HasData(new List<Player>
            {
                new Player
                {
                    GameId = 1,
                    UserId = "c51a5105-1bc9-44c1-ac95-aaad7b313f44",
                    StatusId = 1
                },
                new Player
                {
                    GameId = 1,
                    UserId =  "accdf374-a78f-4664-bc8d-0b8a72cb0a6d",
                    StatusId = 2
                }
            });
        }

        public DbSet<Capture> Captures { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatus> PlayerStatuses { get; set; }
    }
}
