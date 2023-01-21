using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Repositories
{
    public class ResourceManagerAssignmentRepo : IResourceManagerAssignmentRepo
    {

        // DI Injenction
        private readonly AssignDbContext _dbContext;

        public ResourceManagerAssignmentRepo(AssignDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResourceMangerAssignments> AddResource(ResourceMangerAssignments resource)
        {
           
           var dbResource =await _dbContext.ResourceMangerAssignments.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
            resource.Id = dbResource.Entity.Id;
            var resourcedb = await GetResourceById(resource.Id);
            return resourcedb;
        }

        public async Task<IEnumerable<ResourceMangerAssignments>> GetAllResourceAsync()
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).ToListAsync();
        }

        public async Task<ResourceMangerAssignments> GetResourceById(int Id)
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
