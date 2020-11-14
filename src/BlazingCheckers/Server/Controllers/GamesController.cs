using BlazingCheckers.Server.Data;
using BlazingCheckers.Shared.Contracts;
using BlazingCheckers.Shared.Contracts.Queries;
using BlazingCheckers.Shared.Entities;
using BlazingCheckers.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingCheckers.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IApiListResponse<GameModel>>> GetAllGames([FromQuery] PaginationQuery paginationQuery = null)
        {
            try
            {
                IQueryable<Game> query = _context.Games.Include(g => g.Status);
                
                if (paginationQuery == null)
                {
                    return Ok(new ApiListResponse<GameModel>(await query.Select(g => new GameModel(g)).ToListAsync()));
                }

                int maxPageNumber = (int)Math.Ceiling((double)query.Count() / paginationQuery.PageSize);

                if (paginationQuery.PageNumber > maxPageNumber)
                    paginationQuery.PageNumber = maxPageNumber;

                query = query.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize);

                var games = await query.Select(g => new GameModel(g)).ToListAsync();

                return Ok(new ApiPagedResponse<GameModel>(games, paginationQuery.PageNumber, paginationQuery.PageSize, maxPageNumber));
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}