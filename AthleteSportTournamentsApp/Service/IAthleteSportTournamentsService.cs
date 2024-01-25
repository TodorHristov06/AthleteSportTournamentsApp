using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Service
{
    public interface IAthleteSportTournamentsService
    {
        public Task Add(AthleteTournament athleteSportTournaments);
        public Task Update(int id, AthleteTournament athleteSAthleteSportTournament);
        public Task Delete(int id);
        public Task<AthleteTournament> GetById(int id);
        public Task<List<AthleteTournament>> GetAll();
    }
}
