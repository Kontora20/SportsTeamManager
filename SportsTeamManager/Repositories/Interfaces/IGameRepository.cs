using SportsTeamManager.Models;
using System.Collections.Generic;

namespace SportsTeamManager.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetUpcomingGames(int id);

        IEnumerable<Game> GetPreviousGames(int id);
    }
}
