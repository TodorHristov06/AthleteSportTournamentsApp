using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Service
{
    public interface ITournamentService
    {
        public Task Add(Tournament tournament);
        public Task Update(Tournament tournament);
        public Task Delete(int id);
        public Task<Tournament> GetById(int id);
        public Task<List<Tournament>> GetAll();
    }
}
