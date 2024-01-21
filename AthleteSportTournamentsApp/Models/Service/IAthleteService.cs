using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;

namespace AthleteSportTournamentsApp.Models.Service
{
    public interface IAthleteService
    {
        IEnumerable<AthleteDTO> GetAllAthletes();
        AthleteDTO GetAthleteById(int id);
        AthleteDTO CreateAthlete(AthleteDTO athleteDTO);
        AthleteDTO UpdateAthlete(int id, AthleteDTO athleteDTO);
        void DeleteAthlete(int id);
    }
}
