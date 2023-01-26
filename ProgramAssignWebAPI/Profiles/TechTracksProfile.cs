using AutoMapper;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;
using ProgramAssignWebAPI.Repositories;

namespace ProgramAssignWebAPI.Profiles
{
    public class TechTracksProfile : Profile
    {
        public TechTracksProfile()
        {
            CreateMap<TechTracksDto, TechTracks>().ReverseMap();
        }
    }
}
