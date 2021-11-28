using SportsTeamManager.Models;
using SportsTeamManager.Repositories.Interfaces;
using System.Collections.Generic;

namespace SportsTeamManager.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IInMemoryContext _context;

        public GameRepository(IInMemoryContext context)
        {
            _context = context;
        }

        public void Add(Game entity)
        {
            _context.Games.Add(entity);
        }

        public void Delete(Game entity)
        {
            _context.Games.Remove(entity);
        }

        public Game Get(int id)
        {
            return _context.Games.Find(x => x.Id == id);
        }

        public IEnumerable<Game> GetUpcomingGames(int teamId)
        {
            return _context.Games.FindAll(x => (x.HomeTeamId == teamId || x.AwayTeamId == teamId) && x.Date > System.DateTime.UtcNow);
        }

        public IEnumerable<Game> GetPreviousGames(int teamId)
        {
            return _context.Games.FindAll(x => (x.HomeTeamId == teamId || x.AwayTeamId == teamId) && x.Date < System.DateTime.UtcNow);
        }
    }
}
