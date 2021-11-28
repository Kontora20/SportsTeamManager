using SportsTeamManager.Models;
using SportsTeamManager.Repositories.Interfaces;

namespace SportsTeamManager.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IInMemoryContext _context;

        public TeamRepository(IInMemoryContext context)
        {
            _context = context;
        }

        public void Add(Team entity)
        {
            _context.Teams.Add(entity);
        }

        public void Delete(Team entity)
        {
            _context.Teams.Remove(entity);
        }

        public Team Get(int id)
        {
            return _context.Teams.Find(x => x.Id == id);
        }
    }
}
