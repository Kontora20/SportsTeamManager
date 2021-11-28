using System;

namespace SportsTeamManager.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}
