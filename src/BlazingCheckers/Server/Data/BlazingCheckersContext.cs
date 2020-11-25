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
            builder.Entity<Capture>().HasOne(e => e.Move).WithMany().HasForeignKey(e => e.MoveId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Capture>().HasOne(e => e.Piece).WithOne().HasForeignKey<Capture>(e => e.PieceId);

            builder.Entity<Game>().HasOne(e => e.Status).WithMany().HasForeignKey(e => e.StatusId);

            builder.Entity<GamePiece>().HasOne(e => e.Game).WithMany().HasForeignKey(e => e.GameId);
            builder.Entity<GamePiece>().HasOne(e => e.Player).WithMany().HasForeignKey(e => new { e.GameId, e.UserId });

            builder.Entity<Move>().HasOne(e => e.Game).WithMany().HasForeignKey(e => e.GameId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Move>().HasOne(e => e.Piece).WithMany().HasForeignKey(e => e.PieceId);
            builder.Entity<Move>().HasOne(e => e.Player).WithMany().HasForeignKey(e => new { e.GameId, e.UserId });

            builder.Entity<Player>().HasKey(e => new { e.GameId, e.UserId });
            builder.Entity<Player>().HasOne(e => e.Game).WithMany().HasForeignKey(e => e.GameId);
            builder.Entity<Player>().HasOne(e => e.Status).WithMany().HasForeignKey(e => e.StatusId);
            builder.Entity<Player>().HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);

            builder.Entity<GameStatus>().HasData(new List<GameStatus>
            {
                new GameStatus { Id = 1, Status = "Pending" },
                new GameStatus { Id = 2, Status = "Active" },
                new GameStatus { Id = 3, Status = "Completed" },
                new GameStatus { Id = 4, Status = "Timed Out"}
            });

            //builder.Entity<Game>().HasData(new List<Game>
            //{
            //    new Game { Id = 1, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 2 },
            //    new Game { Id = 2, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 2 },
            //    new Game { Id = 3, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
            //    new Game { Id = 4, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
            //    new Game { Id = 5, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 3 },
            //    new Game { Id = 6, CreatedOn = new System.DateTime(2020, 01, 01), StatusId = 4 }
            //});
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
