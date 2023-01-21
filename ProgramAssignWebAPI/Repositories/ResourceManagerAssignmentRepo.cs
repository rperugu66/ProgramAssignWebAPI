using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;
using System;

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
            Random random = new Random();
           
            var getAllPrograms =  _dbContext.ProgramsTracker.Where(x => x.TechTrack == resource.TechTrack).Select(x =>x.Id).ToArray();
            
            var index = random.Next(getAllPrograms.Count());
            resource.ProgramsTrackerId = getAllPrograms[index];
                

            //resource.ProgramsTrackerId = 
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
