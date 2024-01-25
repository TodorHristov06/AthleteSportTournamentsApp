using System.ComponentModel.DataAnnotations;

namespace AthleteSportTournaments.DTOs
{
    public class TournamentDTO
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
