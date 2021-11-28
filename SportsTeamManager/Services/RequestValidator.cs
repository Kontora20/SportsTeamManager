using SportsTeamManager.DTOs;
using SportsTeamManager.Repositories.Interfaces;
using SportsTeamManager.Services.Interfaces;
using System.Linq;

namespace SportsTeamManager
{
    public class RequestValidator : IRequestValidator
    {
        private readonly IPlayerRepository _playerRepository;

        public RequestValidator(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool IsCreatePlayerValid(int teamId, CreatePlayer payload, out string errorDescription)
        {
            errorDescription = "";
            if (IsJerseyNoExistsInTeam(teamId, payload))
            {
                errorDescription = "Player with the same jersey number exists in the current team";
                return false;
            }

            return true;
        }

        private bool IsJerseyNoExistsInTeam(int teamId, CreatePlayer payload)
        {
            var players = _playerRepository.GetPlayersByTeamId(teamId);

            if (players.Any(x => x.JerseyNo == payload.JerseyNo))
                return true;
            else
                return false;
        }
    }
}
