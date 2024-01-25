using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;

namespace AthleteSportTournamentsApp.Service
{
    public interface ISportService
    {
        public Task Add(Sport sport);
        public Task Update(Sport sport);
        public Task Delete(int id);
        public Task<Sport> GetById(int id);
        public Task<List<Sport>> GetAll();
    }
}
