using AutoMapper;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;

namespace ProgramAssignWebAPI.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employees, EmployeeDto>().ReverseMap();
        }
    }
}
