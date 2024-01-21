using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/tournaments")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public IActionResult GetAllTournaments()
        {
            var tournaments = _tournamentService.GetAllTournaments();
            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public IActionResult GetTournamentById(int id)
        {
            var tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament);
        }

        [HttpPost]
        public IActionResult CreateTournament([FromBody] TournamentDTO tournamentDTO)
        {
            var createdTournament = _tournamentService.CreateTournament(tournamentDTO);
            return CreatedAtAction(nameof(GetTournamentById), new { id = createdTournament.TournamentId }, createdTournament);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTournament(int id, [FromBody] TournamentDTO tournamentDTO)
        {
            var updatedTournament = _tournamentService.UpdateTournament(id, tournamentDTO);
            if (updatedTournament == null)
            {
                return NotFound();
            }
            return Ok(updatedTournament);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTournament(int id)
        {
            _tournamentService.DeleteTournament(id);
            return NoContent();
        }

    }
}
