using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public interface IProgramTrackerRepo
    {
        Task<IEnumerable<ProgramsTracker>> GetAllProgramTrackersAsync();   
        Task<ProgramsTracker> GetProgramsTracker(int Id);
        Task<IEnumerable<string>> GetTechTracksAsync();
    }
}
