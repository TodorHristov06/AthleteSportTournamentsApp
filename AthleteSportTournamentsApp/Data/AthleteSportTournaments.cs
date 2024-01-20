namespace AthleteSportTournamentsApp.Data
{
    public class AthleteSportTournaments
    {
        public int AthleteId { get; set; }
        public int SportId { get; set; }
        public int TournamentId { get; set; }

        public Athlete Athlete { get; set; }

        public Sport Sport { get; set; }

        public Tournament Tournament { get; set; }
    }
}
