namespace AthleteSportTournamentsApp.Data
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public int SportId { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<AthleteSportTournaments> AthleteSportTournaments { get; set; }

        public Sport Sport { get; set; }
    }
}
