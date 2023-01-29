using AutoMapper;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;
using ProgramAssignWebAPI.Repositories;

namespace ProgramAssignWebAPI.Profiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfoDto, UserInfo>().ReverseMap();    
        }
    }
}
