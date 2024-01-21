using AthleteSportTournamentsApp.Data;
using AthleteSportTournaments.DTOs;
using AutoMapper;

namespace AthleteSportTournamentsApp.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentDTO>();
            CreateMap<TournamentDTO, Tournament>();
        }
    }
}
