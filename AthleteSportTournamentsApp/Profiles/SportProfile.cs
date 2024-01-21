using AthleteSportTournaments.DTOs;
using AthleteSportTournamentsApp.Data;
using AutoMapper;

namespace AthleteSportTournamentsApp.Profiles
{
    public class SportProfile : Profile
    {
        public SportProfile()
        {
            CreateMap<Sport, SportDTO>();
            CreateMap<SportDTO, Sport>();
        }
    }
}
