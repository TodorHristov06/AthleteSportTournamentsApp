using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;

namespace AthleteSportTournamentsApp.Service
{
    public interface IAthleteService
    {
        public Task Add(Athlete athlete);
        public Task Update(Athlete athlete);
        public Task Delete(int id);
        public Task<Athlete> GetById(int id);
        public Task<List<Athlete>> GetAll();
    }
}
