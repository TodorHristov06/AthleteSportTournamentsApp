using AthleteSportTournamentsApp.Data;
using AthleteSportTournamentsApp.DTOs;
using AutoMapper;


namespace AthleteSportTournamentsApp.Profiles
{
    public class AthleteProfile : Profile
    {
        public AthleteProfile()
        {
            CreateMap<Athlete, AthleteDTO>();
            CreateMap<AthleteDTO, Athlete>();
        }
    }
}
