using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly ICrudRepository<Tournament> _repository;

        public TournamentService(ICrudRepository<Tournament> repository)
        {
            _repository = repository;
        }

        public async Task Add(Tournament tournament)
        {
            await _repository.AddAsync(tournament);
        }

        public async Task Update(Tournament tournament)
        {
            var existingTournament = await _repository.GetByIdAsync(tournament.Id);
            if (existingTournament != null)
            {
                await _repository.UpdateAsync(existingTournament);
            }
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public Task<Tournament> GetById(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<Tournament>> GetAll()
        {
            return _repository.GetAllAsync();
        }
    }
}
