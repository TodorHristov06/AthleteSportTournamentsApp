using AthleteSportTournamentsApp.DTOs;
using AthleteSportTournamentsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/athletes")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public AthleteController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        [HttpGet]
        public IActionResult GetAllAthletes()
        {
            var athletes = _athleteService.GetAllAthletes();
            return Ok(athletes);
        }

        [HttpGet("{id}")]
        public IActionResult GetAthleteById(int id)
        {
            var athlete = _athleteService.GetAthleteById(id);
            if (athlete == null)
            {
                return NotFound();
            }
            return Ok(athlete);
        }

        [HttpPost]
        public IActionResult CreateAthlete([FromBody] AthleteDTO athleteDTO)
        {
            var createdAthlete = _athleteService.CreateAthlete(athleteDTO);
            return CreatedAtAction(nameof(GetAthleteById), new { id = createdAthlete.AthleteId }, createdAthlete);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAthlete(int id, [FromBody] AthleteDTO athleteDTO)
        {
            var updatedAthlete = _athleteService.UpdateAthlete(id, athleteDTO);
            if (updatedAthlete == null)
            {
                return NotFound();
            }
            return Ok(updatedAthlete);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAthlete(int id)
        {
            _athleteService.DeleteAthlete(id);
            return NoContent();
        }
    }
}
