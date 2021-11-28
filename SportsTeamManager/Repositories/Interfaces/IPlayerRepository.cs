using SportsTeamManager.Models;
using System.Collections.Generic;

namespace SportsTeamManager.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayersByTeamId(int teamId);
        void Add(Player player);
        List<int> GetAllIds();
        Player Get(int playerId);
    }
}
