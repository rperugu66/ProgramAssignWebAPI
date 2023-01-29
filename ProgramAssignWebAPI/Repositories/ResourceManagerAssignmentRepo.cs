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

        public async Task<ResourceMangerAssignments?> DeletResource(int id)
        {

            // Get the item from db to delete 
            var resourcedb = await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.Id == id);
            if (resourcedb == null)
                return null;
            _dbContext.Remove(resourcedb);
            await _dbContext.SaveChangesAsync();
            return (resourcedb);
            // remove 

        }

        public async Task<IEnumerable<ResourceMangerAssignments>> GetAllResourceAsync()
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).ToListAsync();
        }

        public async Task<ResourceMangerAssignments> GetResourceById(int Id)
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ResourceMangerAssignments> UpdateResource(int id, ResourceMangerAssignments resource)
        {
            var resourcefromdb = await _dbContext.ResourceMangerAssignments.FindAsync(id);
            if(resourcefromdb != null)
            {
                resourcefromdb.VAMID = resource.VAMID;
                resourcefromdb.ResourceName = resource.ResourceName;
                resourcefromdb.Email = resource.Email;
                resourcefromdb.TechTrack= resource.TechTrack;
                resourcefromdb.StartDate =resource.StartDate;
                resourcefromdb.EndDate = resource.EndDate;
                resourcefromdb.SME = resource.SME;
                resourcefromdb.Manager = resource.Manager;
                await _dbContext.SaveChangesAsync();
                return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker)
                    .FirstOrDefaultAsync(x => x.Id == resourcefromdb.Id);
            }
            return null;
        }
    }
}
