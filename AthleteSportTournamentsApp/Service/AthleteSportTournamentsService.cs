using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Repositories;

namespace AthleteSportTournamentsApp.Service
{
    public class AthleteSportTournamentsService : IAthleteSportTournamentsService
    {
        private readonly ICrudRepository<AthleteTournament> _repository;
        public AthleteSportTournamentsService(ICrudRepository<AthleteTournament> repository)
        {
            _repository = repository;
        }
        public Task Add(AthleteTournament athleteTournaments)
        {
            return _repository.AddAsync(athleteTournaments);
        }

        public Task Delete(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<AthleteTournament>> GetAll()
        {
            return _repository.GetAllAsync();
        }

        public Task<AthleteTournament> GetById(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task Update(AthleteTournament athleteTournaments)
        {
            return _repository.UpdateAsync(athleteTournaments);
        }

        public Task Update(int id, AthleteTournament athleteSportTournaments)
        {
            throw new NotImplementedException();
        }
    }
}
