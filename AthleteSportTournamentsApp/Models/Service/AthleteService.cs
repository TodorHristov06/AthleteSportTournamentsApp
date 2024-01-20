using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Models.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Models.Service
{
    public class AthleteService : IAthleteService
    {
        private readonly IRepository<Athlete> _athleteRepository;
        private readonly IMapper _mapper;

        public AthleteService(IRepository<Athlete> athleteRepository, IMapper mapper)
        {
            _athleteRepository = athleteRepository;
            _mapper = mapper;
        }

        public IEnumerable<AthleteDTO> GetAllAthletes()
        {
            var athletes = _athleteRepository.GetAll();
            return _mapper.Map<IEnumerable<AthleteDTO>>(athletes);
        }

        public AthleteDTO GetAthleteById(int id)
        {
            var athlete = _athleteRepository.GetById(id);
            return _mapper.Map<AthleteDTO>(athlete);
        }

        public AthleteDTO CreateAthlete(AthleteDTO athleteDTO)
        {
            var athlete = _mapper.Map<Athlete>(athleteDTO);
            _athleteRepository.Add(athlete);
            _athleteRepository.Save();

            return _mapper.Map<AthleteDTO>(athlete);
        }

        public AthleteDTO UpdateAthlete(int id, AthleteDTO athleteDTO)
        {
            var existingAthlete = _athleteRepository.GetById(id);

            if (existingAthlete == null)
            {
                return null;
            }

            _mapper.Map(athleteDTO, existingAthlete);
            _athleteRepository.Update(existingAthlete);
            _athleteRepository.Save();

            return _mapper.Map<AthleteDTO>(existingAthlete);
        }

        public void DeleteAthlete(int id)
        {
            var athlete = _athleteRepository.GetById(id);

            if (athlete != null)
            {
                _athleteRepository.Delete(athlete);
                _athleteRepository.Save();
            }
        }
    }
}
