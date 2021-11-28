using SportsTeamManager.DTOs;
using SportsTeamManager.Models;
using SportsTeamManager.Repositories;
using SportsTeamManager.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportsTeamManager.Services
{
    public class TeamManagerService : ITeamManagerService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public TeamManagerService(
            IGameRepository gameRepository,
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        public IEnumerable<Game> GetUpcomingGames(int teamId)
        {
            return _gameRepository.GetUpcomingGames(teamId);
        }

        public IEnumerable<Game> GetPreviousGames(int teamId)
        {
            return _gameRepository.GetPreviousGames(teamId);
        }

        public List<Player> GetTeamPlayers(int teamId)
        {
            return _playerRepository.GetPlayersByTeamId(teamId);
        }      

        public void AddPlayer(int teamId, CreatePlayer player)
        {
            var teamToAddPlayer = _teamRepository.Get(teamId);

            if (teamToAddPlayer == null)
            {
                // It would be possible to create a more specific Exceptions when certain required entities are not found.
                throw new KeyNotFoundException($"Couldn't find a team by provided team id: {teamId}");
            }

            var playersIds = _playerRepository.GetAllIds();
            var latestPlayerId = playersIds.Max();

            // Increment "global" player list id by one so the client wouldn't need to know available player ids to create a player.
            _playerRepository.Add(MapToPlayer(player, latestPlayerId++, teamId)); 
        }

        private Player MapToPlayer(CreatePlayer createPlayer, int playerId, int teamId)
        {
            return new Player { Id = playerId, TeamId = teamId, JerseyNo = createPlayer.JerseyNo, Name = createPlayer.Name };
        }

        public void RemovePlayer(int teamId, int playerId)
        {
            var teamToRemoveFrom = _teamRepository.Get(teamId);
            var playerToRemove = _playerRepository.Get(playerId);

            teamToRemoveFrom.Players.Remove(playerToRemove);
            // Doing this for data consistency, although with current implementation this player would get "lost" completely and it wouldn't
            // be possible to add it to any other team. Only his/hers previous/upcoming games could be seen.
            playerToRemove.TeamId = null;
        }
    }
}
