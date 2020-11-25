using AutoMapper;
using BlazingCheckers.Server.Data.Entities;
using BlazingCheckers.Server.Repositories;
using BlazingCheckers.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlazingCheckers.Server.Controllers
{
    [Authorize]
    [Route("api/users/current/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DbGamesRepository _repo;
        private readonly UserManager<User> _userManager;
        public GamesController(IMapper mapper, DbGamesRepository repo, UserManager<User> userManager)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetGamesForCurrentUser()
        {
            try
            {
                var games = _repo.GetGamesForUser(_userManager.GetUserId(User));
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
                var games = _repo.GetActiveGamesForUser(_userManager.GetUserId(User));
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
                var games = _repo.GetCompletedGamesForUser(_userManager.GetUserId(User));
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
