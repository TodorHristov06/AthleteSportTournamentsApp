using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Service;
using AthleteSportTournamentsApp.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{
    public class AthleteService : IAthleteService
    {
        private readonly ICrudRepository<Athlete> _repository;
        public AthleteService(ICrudRepository<Athlete> repository)
        {
            _repository = repository;
        }
        public Task Add(Athlete athlete)
        {
            return _repository.AddAsync(athlete);
        }

        public Task Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<Athlete>> GetAll()
        {
            return _repository.GetAllAsync();
        }

        public Task<Athlete> GetById(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task Update(Athlete athlete)
        {
            return _repository.UpdateAsync(athlete);
        }
    }
}
