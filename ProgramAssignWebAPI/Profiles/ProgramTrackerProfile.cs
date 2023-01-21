using AutoMapper;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;

namespace ProgramAssignWebAPI.Profiles
{
    public class ProgramTrackerProfile :Profile
    {
        public ProgramTrackerProfile()
        {
            CreateMap<ProgramsTracker, ProgramTrackerDto>().ReverseMap();
        }
    }
}
