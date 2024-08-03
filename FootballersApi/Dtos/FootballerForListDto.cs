namespace FootballersApi.Dtos
{
    public class FootballerForListDto
    {
        public FootballerForListDto()
        {
            BirthDay.ToShortDateString();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
        public string TeamName { get; set; }
        public decimal MarketValue { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public DateTime ContractDate { get; set; }
        public int ContractDuration { get; set; }
        public string Photo { get; set; }
    }
}
