using SportsTeamManager.Repositories;
using SportsTeamManager.Repositories.Interfaces;
using SportsTeamManager.Services;
using SportsTeamManager.Services.Interfaces;
using Xunit;

namespace SportsTeamManager.Tests
{
    public class DependencySetup : IClassFixture<InMemoryFixture>
    {
        public IPlayerRepository PlayerRepositoryMock { get; set; }
        public IGameRepository GameRepositoryMock { get; set; }
        public ITeamRepository TeamRepositoryMock { get; set; }

        private InMemoryFixture _fixture;

        public DependencySetup(InMemoryFixture fixture)
        {
            _fixture = fixture;
            PlayerRepositoryMock = new PlayerRepository(_fixture.MemoryContext);
            GameRepositoryMock = new GameRepository(_fixture.MemoryContext);
            TeamRepositoryMock = new TeamRepository(_fixture.MemoryContext);
        }

        public ITeamManagerService GetTeamManagerServiceMock()
        {
            return new TeamManagerService(GameRepositoryMock, PlayerRepositoryMock, TeamRepositoryMock);
        }

        public IRequestValidator GetRequestValidatorMock()
        {
            return new RequestValidator(PlayerRepositoryMock);
        }
    }
}
