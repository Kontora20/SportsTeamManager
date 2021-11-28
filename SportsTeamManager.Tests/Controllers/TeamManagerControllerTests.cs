using SportsTeamManager.Controllers;
using SportsTeamManager.Services;
using SportsTeamManager.Services.Interfaces;
using Xunit;

namespace SportsTeamManager.Tests.Controllers
{
    public class TeamManagerControllerTests : IClassFixture<InMemoryFixture>
    {
        private readonly ITeamManagerService _teamManagerServiceMock;
        private readonly IRequestValidator _requestValidatorMock;

        private readonly TeamManagerController _target;

        private InMemoryFixture _fixture;

        public TeamManagerControllerTests(InMemoryFixture fixture)
        {
            _fixture = fixture;
            DependencySetup dependencySetup = new DependencySetup(_fixture);

            _teamManagerServiceMock = dependencySetup.GetTeamManagerServiceMock();
            _requestValidatorMock = dependencySetup.GetRequestValidatorMock();

            _target = new TeamManagerController(_teamManagerServiceMock, _requestValidatorMock);
        }

        [Fact]
        public void GetPlayers_ReturnsPlayers_OnCorrectTeamId()
        {
            var teamId = 1;

            var result = _target.GetPlayers(teamId);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
