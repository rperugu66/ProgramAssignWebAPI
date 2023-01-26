using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public interface ITechTracks
    {
        Task<IEnumerable<TechTracks>> GetAllTracks();
    }
}
