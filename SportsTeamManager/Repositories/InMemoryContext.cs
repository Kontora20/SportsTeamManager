using SportsTeamManager.Models;
using SportsTeamManager.Repositories;
using System.Collections.Generic;

namespace SportsTeamManager
{
    public class InMemoryContext : IInMemoryContext
    {
        public List<Player> Players { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }

        public void Initialize()
        {
            Players = new List<Player>();
            Teams = new List<Team>();
            Games = new List<Game>();

            var player1 = new Player { Id = 1, TeamId = 1, Name = "Player the First", JerseyNo = 00 };
            var player2 = new Player { Id = 2, TeamId = 1, Name = "Player the Second", JerseyNo = 01 };
            var player3 = new Player { Id = 3, TeamId = 2, Name = "Player the Third", JerseyNo = 10 };
            var player4 = new Player { Id = 4, TeamId = 2, Name = "Player the Fourth", JerseyNo = 11 };

            var team1 = new Team { Id = 1, Name = "Team One", Players = new List<Player> { player1, player2 } };
            var team2 = new Team { Id = 2, Name = "Team Two", Players = new List<Player> { player3, player4 } };

            var game1 = new Game { Id = 1, Date = System.DateTime.UtcNow.AddDays(3), AwayTeamId = team1.Id, HomeTeamId = team2.Id };
            var game2 = new Game { Id = 1, Date = System.DateTime.UtcNow.AddDays(-5), AwayTeamId = team2.Id, HomeTeamId = team1.Id };

            var playerList = new List<Player> { player1, player2, player3, player4 };
            Players.AddRange(playerList);

            Teams.Add(team1);
            Teams.Add(team2);

            Games.Add(game1);
            Games.Add(game2);
        }
    }
}
