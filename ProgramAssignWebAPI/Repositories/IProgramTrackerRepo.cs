using ProgramAssignWebAPI.Models.Domain;
using System.Data;

namespace ProgramAssignWebAPI.Repositories
{
    public interface IProgramTrackerRepo
    {
        Task<IEnumerable<ProgramsTracker>> GetAllProgramTrackersAsync();   
        Task<ProgramsTracker> GetProgramsTracker(int Id);
        Task<IEnumerable<string>> GetTechTracksAsync();
        Task<IEnumerable<string>> GetCategoriesByTechTrack(string techTrack);
        Task<IEnumerable<ProgramsTracker>> GetProgramsByCategory(string techTrack, string category);
    }
}
