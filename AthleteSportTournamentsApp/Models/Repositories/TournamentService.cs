using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Models.Service;
using AutoMapper;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public IEnumerable<TournamentDTO> GetAllTournaments()
        {
            var tournaments = _tournamentRepository.GetAll();
            var tournamentDTOs = _mapper.Map<IEnumerable<TournamentDTO>>(tournaments);
            return tournamentDTOs;
        }

        public TournamentDTO GetTournamentById(int id)
        {
            var tournament = _tournamentRepository.GetById(id);
            return _mapper.Map<TournamentDTO>(tournament);
        }

        public TournamentDTO CreateTournament(TournamentDTO tournamentDTO)
        {
            var tournament = _mapper.Map<Tournament>(tournamentDTO);
            _tournamentRepository.Add(tournament);
            _tournamentRepository.Save();
            return _mapper.Map<TournamentDTO>(tournament);
        }

        public TournamentDTO UpdateTournament(int id, TournamentDTO tournamentDTO)
        {
            var existingTournament = _tournamentRepository.GetById(id);
            if (existingTournament == null)
            {
                return null;
            }

            _mapper.Map(tournamentDTO, existingTournament);
            _tournamentRepository.Update(existingTournament);
            _tournamentRepository.Save();
            return _mapper.Map<TournamentDTO>(existingTournament);
        }

        public void DeleteTournament(int id)
        {
            var tournament = _tournamentRepository.GetById(id);
            if (tournament != null)
            {
                _tournamentRepository.Delete(tournament);
                _tournamentRepository.Save();
            }
        }
    }
}
