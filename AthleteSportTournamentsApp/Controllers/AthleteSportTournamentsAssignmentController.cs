using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/athletesporttournaments")]
    public class AthleteSportTournamentsAssignmentController : ControllerBase
    {
        private readonly IAthleteSportTournamentsService _athleteSportTournamentsService;

        public AthleteSportTournamentsAssignmentController(IAthleteSportTournamentsService athleteSportTournamentsService)
        {
            _athleteSportTournamentsService = athleteSportTournamentsService;
        }

        [HttpGet("athlete/{id}")]
        public IActionResult GetSportsByAthleteId(int id)
        {
            var sports = _athleteSportTournamentsService.GetSportsByAthleteId(id);
            return Ok(sports);
        }

        [HttpGet("sport/{id}")]
        public IActionResult GetAthletesBySportId(int id)
        {
            var athletes = _athleteSportTournamentsService.GetAthletesBySportId(id);
            return Ok(athletes);
        }

        [HttpPost("assign")]
        public IActionResult AssignAthleteToSport([FromBody] AthleteSportTournamentsDTO assignmentDTO)
        {
            _athleteSportTournamentsService.AssignAthleteToSport(assignmentDTO);
            return Ok();
        }

        [HttpDelete("remove/athlete/{athleteId}/sport/{sportId}")]
        public IActionResult RemoveAthleteSportAssociation(int athleteId, int sportId)
        {
            _athleteSportTournamentsService.RemoveAthleteSportAssociation(athleteId, sportId);
            return NoContent();
        }
    }
}
