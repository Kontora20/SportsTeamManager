using SportsTeamManager.Repositories;
using SportsTeamManager.Repositories.Interfaces;
using SportsTeamManager.Services;
using Xunit;

namespace SportsTeamManager.Tests.Services
{
    public class TeamManagerServiceTests : IClassFixture<InMemoryFixture>
    {
        private InMemoryFixture _fixture;

        private ITeamManagerService _target;

        public TeamManagerServiceTests(InMemoryFixture fixture)
        {
            _fixture = fixture;

            DependencySetup dependencySetup = new DependencySetup(_fixture);

            _target = new TeamManagerService(
                dependencySetup.GameRepositoryMock,
                dependencySetup.PlayerRepositoryMock,
                dependencySetup.TeamRepositoryMock);
        }

        [Fact]
        public void GetTeamPlayers_ReturnPlayers_OnCorrectTeamId()
        {
            int teamId = 1;

            var result = _target.GetTeamPlayers(teamId);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
