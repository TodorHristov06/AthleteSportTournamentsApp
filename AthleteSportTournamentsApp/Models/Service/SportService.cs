using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Models.Repositories;
using AutoMapper;

namespace AthleteSportTournamentsApp.Models.Service
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;

        public SportService(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public IEnumerable<SportDTO> GetAllSports()
        {
            var sports = _sportRepository.GetAll();
            var sportDTOs = _mapper.Map<IEnumerable<SportDTO>>(sports);
            return sportDTOs;
        }

        public SportDTO GetSportById(int id)
        {
            var sport = _sportRepository.GetById(id);
            return _mapper.Map<SportDTO>(sport);
        }

        public SportDTO CreateSport(SportDTO sportDTO)
        {
            var sport = _mapper.Map<Sport>(sportDTO);
            _sportRepository.Add(sport);
            _sportRepository.Save();
            return _mapper.Map<SportDTO>(sport);
        }

        public SportDTO UpdateSport(int id, SportDTO sportDTO)
        {
            var existingSport = _sportRepository.GetById(id);
            if (existingSport == null)
            {
                return null; // or throw an exception indicating not found
            }

            _mapper.Map(sportDTO, existingSport);
            _sportRepository.Update(existingSport);
            _sportRepository.Save();
            return _mapper.Map<SportDTO>(existingSport);
        }

        public void DeleteSport(int id)
        {
            var sport = _sportRepository.GetById(id);
            if (sport != null)
            {
                _sportRepository.Delete(sport);
                _sportRepository.Save();
            }
        }
    }
}
