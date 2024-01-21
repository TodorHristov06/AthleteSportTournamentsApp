using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.DTOs;

namespace AthleteSportTournamentsApp.Models.Service
{
    public interface IAthleteSportTournamentsService
    {
        IEnumerable<AthleteDTO> GetSportsByAthleteId(int athleteId);
        IEnumerable<SportDTO> GetAthletesBySportId(int sportId);
        void AssignAthleteToSport(AthleteSportTournamentsDTO assignmentDTO);
        void RemoveAthleteSportAssociation(int athleteId, int sportId);
    }
}
