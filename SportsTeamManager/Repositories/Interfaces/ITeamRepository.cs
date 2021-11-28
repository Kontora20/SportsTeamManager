using SportsTeamManager.Models;

namespace SportsTeamManager.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Team Get(int id);
        void Delete(Team team);
        void Add(Team entity);
    }
}
