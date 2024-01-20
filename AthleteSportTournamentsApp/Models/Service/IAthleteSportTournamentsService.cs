using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.DTOs;

namespace AthleteSportTournamentsApp.Models.Service
{
    public interface IAthleteSportTournamentsService
    {
        IEnumerable<SportDTO> GetSportsByAthleteId(int athleteId);
        IEnumerable<AthleteDTO> GetAthletesBySportId(int sportId);
        void AssignAthleteToSport(AthleteSportTournamentsDTO assignmentDTO);
        void RemoveAthleteSportAssociation(int athleteId, int sportId);
    }
}
