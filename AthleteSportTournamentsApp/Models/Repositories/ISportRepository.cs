using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public interface ISportRepository
    {
        IEnumerable<Sport> GetSportsByType(string type);
        Sport GetSportByName(string name);
        IEnumerable<Sport> GetSportsInSeason(string season);
    }
}
