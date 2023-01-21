using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public interface IResourceManagerAssignmentRepo
    {
        Task<IEnumerable<ResourceMangerAssignments>> GetAllResourceAsync();
        Task<ResourceMangerAssignments> AddResource(ResourceMangerAssignments resource);

        Task<ResourceMangerAssignments> GetResourceById(int Id);
    }
}
