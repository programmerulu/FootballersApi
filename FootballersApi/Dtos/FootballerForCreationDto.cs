using FootballersApi.Models;

namespace FootballersApi.Dtos
{
    public class FootballerForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MarketValue { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Agent { get; set; }
        public DateTime ContractDate { get; set; }
        public int ContractDuration { get; set; }
        public string Photo { get; set; }
    }
}
