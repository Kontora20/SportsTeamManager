namespace SportsTeamManager.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public string Name { get; set; }
        public ushort JerseyNo { get; set; }
    }
}
