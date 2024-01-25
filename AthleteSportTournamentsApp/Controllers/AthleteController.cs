using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/athletes")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteService _athleteService;
        private readonly IMapper _mapper;

        public AthleteController(IAthleteService athleteService, IMapper mapper)
        {
            _athleteService = athleteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAthletes()
        {
            var athletes = await _athleteService.GetAll();
            var athleteDTOs = _mapper.Map<List<AthleteDTO>>(athletes);
            return Ok(athleteDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAthleteById(int id)
        {
            var athlete = await _athleteService.GetById(id);
            if (athlete == null)
            {
                return NotFound();
            }

            var athleteDTO = _mapper.Map<AthleteDTO>(athlete);
            return Ok(athleteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAthlete([FromBody] AthleteDTO athleteDTO)
        {
            var athlete = _mapper.Map<Athlete>(athleteDTO);
            await _athleteService.Add(athlete);

            var createdAthleteDTO = _mapper.Map<AthleteDTO>(athlete);

            return CreatedAtAction(nameof(GetAthleteById), new { id = createdAthleteDTO.Id }, createdAthleteDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAthlete(int id, [FromBody] AthleteDTO athleteDTO)
        {
            var athlete = _mapper.Map<Athlete>(athleteDTO);
            await _athleteService.Update(athlete);

            var updatedAthlete = await _athleteService.GetById(id);
            if (updatedAthlete == null)
            {
                return NotFound();
            }

            var updatedAthleteDTO = _mapper.Map<AthleteDTO>(updatedAthlete);

            return Ok(updatedAthleteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAthlete(int id)
        {
            await _athleteService.Delete(id);
            return NoContent();
        }
    }
}
