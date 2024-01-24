using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{
    public class SportService : ISportService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SportService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<SportDTO> GetAllSports()
        {
            var sports = _dbContext.Sports.ToList();
            return _mapper.Map<IEnumerable<SportDTO>>(sports);
        }

        public SportDTO GetSportById(int id)
        {
            var sportEntity = _dbContext.Sports.Find(id);
            return sportEntity != null ? _mapper.Map<SportDTO>(sportEntity) : null;
        }

        public SportDTO CreateSport(SportDTO sportDTO)
        {
            var sportEntity = _mapper.Map<Sport>(sportDTO);
            _dbContext.Sports.Add(sportEntity);
            _dbContext.SaveChanges();
            return _mapper.Map<SportDTO>(sportEntity);
        }

        public SportDTO UpdateSport(int id, SportDTO sportDTO)
        {
            var sportEntity = _dbContext.Sports.Find(id);

            if (sportEntity != null)
            {
                _mapper.Map(sportDTO, sportEntity);
                _dbContext.SaveChanges();
                return _mapper.Map<SportDTO>(sportEntity);
            }

            return null;
        }

        public void DeleteSport(int id)
        {
            var sportEntity = _dbContext.Sports.Find(id);

            if (sportEntity != null)
            {
                _dbContext.Sports.Remove(sportEntity);
                _dbContext.SaveChanges();
            }
        }
    }
}
