namespace FootballersApi.Models
{
    public class Team
    {
        public Team()
        {
            Footballers = new List<Footballer>();
        }
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int FoundationYear { get; set; }
        public string CurrentPresident { get; set; }
        public string Stadium { get; set; }
        public decimal CurrentTransferBalance { get; set; }

        public List<Footballer> Footballers { get; set; }
    }
}
