using SportsTeamManager.DTOs;
using SportsTeamManager.Models;
using System.Collections.Generic;

namespace SportsTeamManager.Services
{
    public interface ITeamManagerService
    {
        IEnumerable<Game> GetUpcomingGames(int teamId);
        IEnumerable<Game> GetPreviousGames(int teamId);
        List<Player> GetTeamPlayers(int teamId);
        void AddPlayer(int teamId, CreatePlayer player);
        void RemovePlayer(int teamId, int playerId);
    }
}
