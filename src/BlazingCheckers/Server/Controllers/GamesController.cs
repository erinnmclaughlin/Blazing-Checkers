using AutoMapper;
using BlazingCheckers.Server.Repositories;
using BlazingCheckers.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BlazingCheckers.Server.Controllers
{
    [Authorize]
    [Route("api/users/current/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DbGamesRepository _repo;

        public GamesController(IMapper mapper, DbGamesRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetGamesForCurrentUser()
        {
            try
            {
                var games = _repo.GetGamesForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(_mapper.Map<IEnumerable<GameDto>>(games));
            }
            catch (Exception ex)
            {
                // TODO: log exception
                return StatusCode(500);
            }
        }

        [HttpGet("active")]
        public IActionResult GetActiveGamesForCurrentUser()
        {
            try
            {
                var games = _repo.GetActiveGamesForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(_mapper.Map<IEnumerable<GameDto>>(games));
            }
            catch (Exception ex)
            {
                // TODO: log exception
                return StatusCode(500);
            }
        }

        [HttpGet("completed")]
        public IActionResult GetCompletedGamesForCurrentUser()
        {
            try
            {
                var games = _repo.GetCompletedGamesForUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(_mapper.Map<IEnumerable<GameDto>>(games));
            }
            catch (Exception ex)
            {
                // TODO: log exception
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            try
            {
                var game = _repo.GetGameDetails(id);
                return Ok(_mapper.Map<GameDto>(game));
            }
            catch (Exception ex)
            {
                // TODO: log exception
                return StatusCode(500);
            }
        }

    }
}
