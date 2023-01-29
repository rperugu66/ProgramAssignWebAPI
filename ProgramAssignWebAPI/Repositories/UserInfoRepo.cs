using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{

    public class UserInfoRepo : IUserInfoRepo
    {
        private readonly AssignDbContext _dbContext;

        public UserInfoRepo(AssignDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserInfo> GetUserInfoAsync(int VAMId)
        {
           //call db and get data by VAM id
           var response =await _dbContext.UserInfo.FirstOrDefaultAsync(x=>x.VAMId== VAMId);
            if(response== null)
            {
                return null;
            }
            return response;
        }
    }
}
