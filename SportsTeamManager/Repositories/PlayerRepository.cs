using SportsTeamManager.Models;
using SportsTeamManager.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportsTeamManager.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IInMemoryContext _context;

        public PlayerRepository(IInMemoryContext context)
        {
            _context = context;
        }

        public void Add(Player entity)
        {
            _context.Players.Add(entity);
        }

        public void Delete(Player entity)
        {
            _context.Players.Remove(entity);
        }

        public List<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Players.FindAll(x => x.TeamId == teamId);
        }

        public List<int> GetAllIds()
        {
            return _context.Players.Select(x => x.Id).ToList();
        }

        public Player Get(int playerId)
        {
            return _context.Players.Find(x => x.Id == playerId);
        }
    }
}
