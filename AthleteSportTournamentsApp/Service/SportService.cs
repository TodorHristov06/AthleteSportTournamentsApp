using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{
    public class SportService : ISportService
    {
        private readonly ICrudRepository<Sport> _repository;
        public SportService(ICrudRepository<Sport> repository)
        {
            _repository = repository;
        }
        public Task Add(Sport sport)
        {
            return _repository.AddAsync(sport);
        }

        public Task Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<Sport>> GetAll()
        {
            return _repository.GetAllAsync();
        }

        public Task<Sport> GetById(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task Update(Sport sport)
        {
            return _repository.UpdateAsync(sport);
        }
    }
}
