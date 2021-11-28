using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsTeamManager.DTOs;
using SportsTeamManager.Models;
using SportsTeamManager.Services;
using SportsTeamManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace SportsTeamManager.Controllers
{
    [ApiController]
    public class TeamManagerController : ControllerBase
    {
        private readonly ITeamManagerService _teamManagerService;
        private readonly IRequestValidator _requestValidator;

        public TeamManagerController(ITeamManagerService teamManagerService, IRequestValidator requestValidator)
        {
            _teamManagerService = teamManagerService;
            _requestValidator = requestValidator;
        }

        [HttpGet]
        [Route("team/{teamId}/upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Game> GetUpcoming(int teamId)
        {
            return _teamManagerService.GetUpcomingGames(teamId);
        }

        [HttpGet("team/{teamId}/previous")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Game> GetPrevious(int teamId)
        {
            return _teamManagerService.GetPreviousGames(teamId);
        }

        [HttpGet("team/{teamId}/players")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Player> GetPlayers(int teamId)
        {
            return _teamManagerService.GetTeamPlayers(teamId);
        }

        //[Authorize] <--- non GET actions should be done by an authenticated user, something like JWT, but due time constraints, not implemented.
        [HttpPost("team/{teamId}/player")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult CreatePlayer(int teamId, [FromBody] CreatePlayer player)
        {
            if (!_requestValidator.IsCreatePlayerValid(teamId, player, out string description))
            {
                return BadRequest(description);
            }

            try
            {
                _teamManagerService.AddPlayer(teamId, player);
                // If the entities had properties like "DateCreated" it would be better to return Created() along with the entity created.
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        //[Authorize] <--- non GET actions should be done by an authenticated user, something like JWT, but due time constraints, not implemented.
        [HttpDelete("team/{teamId}/player/{playerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int teamId, int playerId)
        {
            _teamManagerService.RemovePlayer(teamId, playerId);
            return NoContent();
        }
    }
}
