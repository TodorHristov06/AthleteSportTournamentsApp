namespace AthleteSportTournamentsApp.Data
{
    public class Athlete
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public ICollection<AthleteSportTournaments> AthleteSportTournaments { get; set; }
    }
}
