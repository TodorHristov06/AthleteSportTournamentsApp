using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TournamentService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<TournamentDTO> GetAllTournaments()
        {
            var tournaments = _dbContext.Tournaments.ToList();
            return _mapper.Map<IEnumerable<TournamentDTO>>(tournaments);
        }

        public TournamentDTO GetTournamentById(int id)
        {
            var tournamentEntity = _dbContext.Tournaments.Find(id);
            return tournamentEntity != null ? _mapper.Map<TournamentDTO>(tournamentEntity) : null;
        }

        public TournamentDTO CreateTournament(TournamentDTO tournamentDTO)
        {
            var tournamentEntity = _mapper.Map<Tournament>(tournamentDTO);
            _dbContext.Tournaments.Add(tournamentEntity);
            _dbContext.SaveChanges();
            return _mapper.Map<TournamentDTO>(tournamentEntity);
        }

        public TournamentDTO UpdateTournament(int id, TournamentDTO tournamentDTO)
        {
            var tournamentEntity = _dbContext.Tournaments.Find(id);

            if (tournamentEntity != null)
            {
                _mapper.Map(tournamentDTO, tournamentEntity);
                _dbContext.SaveChanges();
                return _mapper.Map<TournamentDTO>(tournamentEntity);
            }

            return null;
        }

        public void DeleteTournament(int id)
        {
            var tournamentEntity = _dbContext.Tournaments.Find(id);

            if (tournamentEntity != null)
            {
                _dbContext.Tournaments.Remove(tournamentEntity);
                _dbContext.SaveChanges();
            }
        }
    }
}
