using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Profiles;
using AthleteSportTournamentsApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/athlete-sport-tournament-assignments")]
    public class AthleteSportTournamentsAssignmentController : ControllerBase
    {
        private readonly IAthleteSportTournamentsService _athleteSportTournamentsService;
        private readonly IMapper _mapper;

        public AthleteSportTournamentsAssignmentController(IAthleteSportTournamentsService athleteSportTournamentsService, IMapper mapper)
        {
            _athleteSportTournamentsService = athleteSportTournamentsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssignments()
        {
            var assignments = await _athleteSportTournamentsService.GetAll();
            var assignmentDTOs = _mapper.Map<List<AthleteTournamentDTO>>(assignments);
            return Ok(assignmentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var assignment = await _athleteSportTournamentsService.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }

            var assignmentDTO = _mapper.Map<AthleteTournamentDTO>(assignment);
            return Ok(assignmentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] AthleteTournamentDTO assignmentDTO)
        {
            var assignment = _mapper.Map<AthleteTournament>(assignmentDTO);
            await _athleteSportTournamentsService.Add(assignment);

            var createdAssignmentDTO = _mapper.Map<AthleteTournamentDTO>(assignment);

            return CreatedAtAction(nameof(GetAssignmentById), createdAssignmentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AthleteTournamentDTO assignmentDTO)
        {
            var assignment = _mapper.Map<AthleteTournament>(assignmentDTO);
            await _athleteSportTournamentsService.Update(id, assignment);

            var updatedAssignment = await _athleteSportTournamentsService.GetById(id);
            if (updatedAssignment == null)
            {
                return NotFound();
            }

            var updatedAssignmentDTO = _mapper.Map<AthleteTournamentDTO>(updatedAssignment);

            return Ok(updatedAssignmentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await _athleteSportTournamentsService.Delete(id);
            return NoContent();
        }
    }
}
