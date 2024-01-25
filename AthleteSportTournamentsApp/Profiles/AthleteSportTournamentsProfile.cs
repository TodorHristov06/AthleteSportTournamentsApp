using AthleteSportTournamentsApp.Data;
using AthleteSportTournaments.DTOs;
using AutoMapper;

namespace AthleteSportTournamentsApp.Profiles
{
    public class AthleteSportTournamentsProfile : Profile
    {
        public AthleteSportTournamentsProfile()
        {
            CreateMap<AthleteTournament, AthleteTournamentDTO>();
            CreateMap<AthleteTournamentDTO, AthleteTournament>();
        }
    }
}
