using SportsTeamManager.Models;
using System.Collections.Generic;

namespace SportsTeamManager.Repositories
{
    public interface IInMemoryContext
    {
        public List<Player> Players { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
        void Initialize();
    }
}
