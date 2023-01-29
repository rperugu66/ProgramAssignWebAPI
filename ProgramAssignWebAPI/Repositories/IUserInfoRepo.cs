using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public interface IUserInfoRepo
    {
        Task<UserInfo> GetUserInfoAsync(int VAMId);
    }
}
