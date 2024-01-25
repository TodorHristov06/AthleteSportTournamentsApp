using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AthleteSportTournamentsApp.Controllers
{
    [ApiController]
    [Route("api/sports")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;
        private readonly IMapper _mapper;

        public SportController(ISportService sportService, IMapper mapper)
        {
            _sportService = sportService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _sportService.GetAll();
            var sportDTOs = _mapper.Map<List<SportDTO>>(sports);
            return Ok(sportDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSportById(int id)
        {
            var sport = await _sportService.GetById(id);
            if (sport == null)
            {
                return NotFound();
            }

            var sportDTO = _mapper.Map<SportDTO>(sport);
            return Ok(sportDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSport([FromBody] SportDTO sportDTO)
        {
            var sport = _mapper.Map<Sport>(sportDTO);
            await _sportService.Add(sport);

            var createdSportDTO = _mapper.Map<SportDTO>(sport);

            return CreatedAtAction(nameof(GetSportById), new { id = createdSportDTO.Id }, createdSportDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSport(int id, [FromBody] SportDTO sportDTO)
        {
            var sport = _mapper.Map<Sport>(sportDTO);
            await _sportService.Update( sport);

            var updatedSport = await _sportService.GetById(id);
            if (updatedSport == null)
            {
                return NotFound();
            }

            var updatedSportDTO = _mapper.Map<SportDTO>(updatedSport);

            return Ok(updatedSportDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSport(int id)
        {
            await _sportService.Delete(id);
            return NoContent();
        }
    }

}
