using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Models.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Models.Repositories
{
    public class AthleteSportTournamentsService : IAthleteSportTournamentsService
    {
        private readonly IAthleteSportTournamentsRepository _athleteSportTournamentsRepository;
        private readonly IMapper _mapper;

        public AthleteSportTournamentsService(IAthleteSportTournamentsRepository athleteSportTournamentsRepository, IMapper mapper)
        {
            _athleteSportTournamentsRepository = athleteSportTournamentsRepository;
            _mapper = mapper;
        }

        public IEnumerable<SportDTO> GetSportsByAthleteId(int athleteId)
        {
            var athleteSports = _athleteSportTournamentsRepository.GetByAthleteId(athleteId);
            var sports = _mapper.Map<IEnumerable<SportDTO>>(athleteSports.Select(ast => ast.Sport));
            return sports;
        }

        public IEnumerable<AthleteDTO> GetAthletesBySportId(int sportId)
        {
            var sportAthletes = _athleteSportTournamentsRepository.GetBySportId(sportId);
            var athletes = _mapper.Map<IEnumerable<AthleteDTO>>(sportAthletes.Select(ast => ast.Athlete));
            return athletes;
        }

        public void AssignAthleteToSport(AthleteSportTournamentsDTO assignmentDTO)
        {
            var athleteSportTournaments = _mapper.Map<AthleteSportTournaments>(assignmentDTO);
            _athleteSportTournamentsRepository.Add(athleteSportTournaments);
            _athleteSportTournamentsRepository.Save();
        }

        public void RemoveAthleteSportAssociation(int athleteId, int sportId)
        {
            var athleteSport = _athleteSportTournamentsRepository.GetAll()
                .FirstOrDefault(ast => ast.AthleteId == athleteId && ast.SportId == sportId);

            if (athleteSport != null)
            {
                _athleteSportTournamentsRepository.Delete(athleteSport);
                _athleteSportTournamentsRepository.Save();
            }
        }
    }
}
