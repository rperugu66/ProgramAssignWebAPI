using AutoMapper;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;

namespace ProgramAssignWebAPI.Profiles

{
    public class ResourceManagerAssignmentProfile: Profile
    {
        public ResourceManagerAssignmentProfile()
        {
            CreateMap<ResourceMangerAssignments, ResourceManagerAssignmentDto>().ReverseMap(); // Converting Region class(source) to Regiondto class (destination) 
            CreateMap<AddResourceDto, ResourceMangerAssignments>();
            CreateMap<EditResourceDto, ResourceMangerAssignments>();
            CreateMap<ResourceManagerAssignmentsHistory, UpdateResourceHistoryDto>().ReverseMap();
            CreateMap<ResourceManagerAssignmentsHistory, ResourceManagerHistoryDto>().ReverseMap();
            CreateMap<ResourceManagerAssignmentsHistory, UpdateResourceHistoryCodeDto>().ReverseMap();
        }
        

    }
}
