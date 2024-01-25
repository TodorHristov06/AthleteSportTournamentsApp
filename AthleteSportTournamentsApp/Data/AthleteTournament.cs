using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthleteSportTournamentsApp.Data
{
    public class AthleteTournament : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(Athlete))]
        public int AthleteId { get; set; }
        [Key]
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }

        public virtual Athlete? Athlete { get; set; }

        public virtual Tournament? Tournament { get; set; }
    }
}
