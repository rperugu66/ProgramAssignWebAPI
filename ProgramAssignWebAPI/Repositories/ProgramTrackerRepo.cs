using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public class ProgramTrackerRepo : IProgramTrackerRepo
    {
        private readonly AssignDbContext _dbContext;

        public ProgramTrackerRepo(AssignDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProgramsTracker>> GetAllProgramTrackersAsync()
        {
            return await _dbContext.ProgramsTracker.ToListAsync();
             
        }

        Task<ProgramsTracker> IProgramTrackerRepo.GetProgramsTracker(int Id)
        {
           return _dbContext.ProgramsTracker.FirstOrDefaultAsync(x =>x.Id == Id);   
        }
    }
}
