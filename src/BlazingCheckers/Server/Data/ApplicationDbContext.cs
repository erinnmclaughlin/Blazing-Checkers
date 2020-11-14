using BlazingCheckers.Shared.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazingCheckers.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Capture>().HasKey(e => new { e.MoveId, e.PieceId });
            builder.Entity<Capture>().HasOne<Move>().WithMany().HasForeignKey(e => e.MoveId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Capture>().HasOne<GamePiece>().WithOne().HasForeignKey<Capture>(e => e.PieceId);

            builder.Entity<Game>().HasOne<GameStatus>().WithMany().HasForeignKey(e => e.StatusId);

            builder.Entity<GamePiece>().HasOne<Game>().WithMany().HasForeignKey(e => e.GameId);
            builder.Entity<GamePiece>().HasOne<Player>().WithMany().HasForeignKey(e => new { e.GameId, e.UserId });

            builder.Entity<Move>().HasOne<Game>().WithMany().HasForeignKey(e => e.GameId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Move>().HasOne<GamePiece>().WithMany().HasForeignKey(e => e.PieceId);
            builder.Entity<Move>().HasOne<Player>().WithMany().HasForeignKey(e => new { e.GameId, e.UserId });

            builder.Entity<Player>().HasKey(e => new { e.GameId, e.UserId });
            builder.Entity<Player>().HasOne<Game>().WithMany().HasForeignKey(e => e.GameId);
            builder.Entity<Player>().HasOne<PlayerStatus>().WithMany().HasForeignKey(e => e.StatusId);
            builder.Entity<Player>().HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
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
