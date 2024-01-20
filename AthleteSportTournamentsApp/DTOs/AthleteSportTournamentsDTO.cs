using System.ComponentModel.DataAnnotations;

namespace AthleteSportTournaments.DTOs
{
    public class AthleteSportTournamentsDTO
    {
        public int AthleteId { get; set; }
        public int SportId { get; set; }
        public int TournamentId { get; set; }
    }
}
