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

        public Task<IEnumerable<string>> GetTechTracksAsync()
        {
            throw new Exception();
            // return _dbContext.ProgramsTracker.Distinct
        }

        Task<ProgramsTracker> IProgramTrackerRepo.GetProgramsTracker(int Id)
        {
           return _dbContext.ProgramsTracker.FirstOrDefaultAsync(x =>x.Id == Id);   
        }
        
        public async Task<IEnumerable<string>> GetCategoriesByTechTrack(string techTrack)
        {
           var categories = await _dbContext.ProgramsTracker.Where(x => x.TechTrack == techTrack).Select(x => x.Category).Distinct().ToListAsync();
           return categories;
        }

        public async Task<IEnumerable<ProgramsTracker>> GetProgramsByCategory(string techTrack, string category)
        {
          var programs = await _dbContext.ProgramsTracker.Where(x => x.TechTrack == techTrack && x.Category == category).Distinct().ToListAsync();

          return programs;

        }
    }
}
