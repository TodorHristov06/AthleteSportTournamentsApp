using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;
using AutoMapper;

namespace AthleteSportTournamentsApp.Service
{

    public class AthleteService : IAthleteService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AthleteService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AthleteDTO CreateAthlete(AthleteDTO athleteDTO)
        {
            // Map the DTO to the entity
            var athleteEntity = _mapper.Map<Athlete>(athleteDTO);

            // Add the entity to the database
            _dbContext.Athletes.Add(athleteEntity);
            _dbContext.SaveChanges();

            // Map the created entity back to DTO
            return _mapper.Map<AthleteDTO>(athleteEntity);
        }

        public void DeleteAthlete(int id)
        {
            // Find the athlete by id
            var athleteEntity = _dbContext.Athletes.Find(id);

            if (athleteEntity != null)
            {
                // Remove the athlete from the database
                _dbContext.Athletes.Remove(athleteEntity);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<AthleteDTO> GetAllAthletes()
        {
            // Retrieve all athletes from the database and map them to DTOs
            var athletes = _dbContext.Athletes.ToList();
            return _mapper.Map<IEnumerable<AthleteDTO>>(athletes);
        }

        public AthleteDTO GetAthleteById(int id)
        {
            // Find the athlete by id and map it to DTO
            var athleteEntity = _dbContext.Athletes.Find(id);
            return athleteEntity != null ? _mapper.Map<AthleteDTO>(athleteEntity) : null;
        }

        public AthleteDTO UpdateAthlete(int id, AthleteDTO athleteDTO)
        {
            // Find the athlete by id
            var athleteEntity = _dbContext.Athletes.Find(id);

            if (athleteEntity != null)
            {
                // Update the athlete's properties with values from the DTO
                _mapper.Map(athleteDTO, athleteEntity);

                _dbContext.SaveChanges();

                // Map the updated entity back to DTO
                return _mapper.Map<AthleteDTO>(athleteEntity);
            }

            return null;
        }
    }
}
