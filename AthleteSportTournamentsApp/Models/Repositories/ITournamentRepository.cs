using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> GetTournamentsBySportId(int sportId);
        Tournament GetTournamentByLocationAndDates(string location, DateTime startDate, DateTime endDate);
    }
}
