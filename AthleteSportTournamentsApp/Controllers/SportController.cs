using AthleteSportTournaments.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/sports")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        public IActionResult GetAllSports()
        {
            var sports = _sportService.GetAllSports();
            return Ok(sports);
        }

        [HttpGet("{id}")]
        public IActionResult GetSportById(int id)
        {
            var sport = _sportService.GetSportById(id);
            if (sport == null)
            {
                return NotFound();
            }
            return Ok(sport);
        }

        [HttpPost]
        public IActionResult CreateSport([FromBody] SportDTO sportDTO)
        {
            var createdSport = _sportService.CreateSport(sportDTO);
            return CreatedAtAction(nameof(GetSportById), new { id = createdSport.SportId }, createdSport);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSport(int id, [FromBody] SportDTO sportDTO)
        {
            var updatedSport = _sportService.UpdateSport(id, sportDTO);
            if (updatedSport == null)
            {
                return NotFound();
            }
            return Ok(updatedSport);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSport(int id)
        {
            _sportService.DeleteSport(id);
            return NoContent();
        }
    }
}
