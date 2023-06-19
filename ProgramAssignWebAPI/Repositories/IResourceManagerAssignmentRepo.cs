using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public interface IResourceManagerAssignmentRepo
    {
        Task<IEnumerable<ResourceMangerAssignments>> GetAllResourceAsync();
        Task<ResourceMangerAssignments> AddResource(ResourceMangerAssignments resource, string category);

        Task<ResourceMangerAssignments> GetResourceById(int Id);
        Task<ResourceMangerAssignments> GetResourceByEmailId(string email);
        Task<ResourceMangerAssignments> UpdateResource(int id,ResourceMangerAssignments resource);
        Task<ResourceMangerAssignments?> DeletResource(int id);
        Task<IEnumerable<ResourceManagerAssignmentsHistory>> GetResourceHistoryById(int Id);
        Task<ResourceManagerAssignmentsHistory> GetResourceHistorySingleById(int Id);
        //Task<ResourceManagerAssignmentsHistory> GetSmeByName(string SME);

        Task<ResourceManagerAssignmentsHistory> UpdateResourceHistory(int id, ResourceManagerAssignmentsHistory resourcehistory, string category);

        Task<ResourceManagerAssignmentsHistory> UpdateResourceHistoryCode(int id, ResourceManagerAssignmentsHistory resourcehistory);
        //Task<IEnumerable<ResourceManagerAssignmentsHistory>> GetAllHistoryResourceAsync();
    }
}
