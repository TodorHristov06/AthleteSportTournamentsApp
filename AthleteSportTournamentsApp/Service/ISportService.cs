using AthleteSportTournaments.DTOs;

namespace AthleteSportTournamentsApp.Service
{
    public interface ISportService
    {
        IEnumerable<SportDTO> GetAllSports();
        SportDTO GetSportById(int id);
        SportDTO CreateSport(SportDTO sportDTO);
        SportDTO UpdateSport(int id, SportDTO sportDTO);
        void DeleteSport(int id);
    }
}
