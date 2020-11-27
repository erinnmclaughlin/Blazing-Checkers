using BlazingCheckers.Server.Data;
using BlazingCheckers.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazingCheckers.Server.Repositories
{
    public class DbGamesRepository : DbRepositoryBase<Game>
    {
        public DbGamesRepository(BlazingCheckersContext context) : base (context)
        {
            _baseQuery = _context.Games.Include(g => g.Players).Include(g => g.Status);
        }

        public IQueryable<Game> GetGamesForUser(string userId)
        {
            return GetAll().Where(g => g.Players.Any(p => p.UserId == userId));
        }

        public IQueryable<Game> GetActiveGamesForUser(string userId)
        {
            return GetGamesForUser(userId).Where(g => g.CompletedOn == null);
        }

        public IQueryable<Game> GetCompletedGamesForUser(string userId)
        {
            return GetGamesForUser(userId).Where(g => g.CompletedOn != null);
        }

        public Game GetGameDetails(int id)
        {
            return _baseQuery
                .Include(g => g.Pieces)
                    .ThenInclude(p => p.Moves)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}