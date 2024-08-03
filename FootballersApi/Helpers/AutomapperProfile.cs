using AutoMapper;
using FootballersApi.Dtos;
using FootballersApi.Models;

namespace FootballersApi.Helpers
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<FootballerForCreationDto,Footballer >();
            CreateMap<Footballer, FootballerForListDto>().ForMember(dest=>dest.TeamName, 
                opt=> opt.MapFrom(src=>src.Team.TeamName));

            CreateMap<Team, TeamForListDto>().ForMember(dest => dest.NumberOfFootballers,
                opt => opt.MapFrom(src => src.Footballers.Count));
        }
    }
}
