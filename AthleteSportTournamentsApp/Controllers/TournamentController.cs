using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/tournaments")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {
            var tournaments = await _tournamentService.GetAll();
            var tournamentDTOs = _mapper.Map<List<TournamentDTO>>(tournaments);
            return Ok(tournamentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournamentById(int id)
        {
            var tournament = await _tournamentService.GetById(id);
            if (tournament == null)
            {
                return NotFound();
            }

            var tournamentDTO = _mapper.Map<TournamentDTO>(tournament);
            return Ok(tournamentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTournament([FromBody] TournamentDTO tournamentDTO)
        {
            var tournament = _mapper.Map<Tournament>(tournamentDTO);
            await _tournamentService.Add(tournament);

            var createdTournamentDTO = _mapper.Map<TournamentDTO>(tournament);

            return CreatedAtAction(nameof(GetTournamentById), new { id = createdTournamentDTO.Id }, createdTournamentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, [FromBody] TournamentDTO tournamentDTO)
        {
            var tournament = _mapper.Map<Tournament>(tournamentDTO);
            await _tournamentService.Update(tournament);

            var updatedTournament = await _tournamentService.GetById(id);
            if (updatedTournament == null)
            {
                return NotFound();
            }

            var updatedTournamentDTO = _mapper.Map<TournamentDTO>(updatedTournament);

            return Ok(updatedTournamentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            await _tournamentService.Delete(id);
            return NoContent();
        }
    }
}
