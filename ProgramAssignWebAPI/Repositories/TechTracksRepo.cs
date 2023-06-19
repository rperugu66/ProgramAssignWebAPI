using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public class TechTracksRepo :ITechTracks
    {

        private readonly AssignDbContext _dbContext;

        public TechTracksRepo(AssignDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TechTracks>> GetAllTracks()
        {
            var techtracks = await _dbContext.TechTracks.ToListAsync();
            return techtracks;
        
        } 

    }
}
