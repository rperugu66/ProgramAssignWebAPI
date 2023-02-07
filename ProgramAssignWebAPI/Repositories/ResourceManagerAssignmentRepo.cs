using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;
using System;
//using TemporalTableWithNavigation;

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
            resource.HistoryProgramTrackerId = getAllPrograms[index].ToString();


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

        public async Task<IEnumerable<ResourceMangerAssignments>> GetResourceHistoryById(int Id)
        {
           var response = await  _dbContext.ResourceMangerAssignments.TemporalAll().Where(x => x.Id == Id).ToListAsync();
           IList<ResourceMangerAssignments> resources = new List<ResourceMangerAssignments>();
            var GetAllPrograms =await _dbContext.ProgramsTracker.ToListAsync();
            foreach (var item in response)
            {
                // make call to service and get programtackerby id
                var programtracker = GetAllPrograms.FirstOrDefault(x => x.Id == item.ProgramsTrackerId);
                    //await _dbContext.ProgramsTracker.FirstOrDefaultAsync(x => x.Id == item.ProgramsTrackerId);
                var newitem = new ResourceMangerAssignments()
                {
                    Id = item.Id,
                    VAMID = item.VAMID,
                    Email = item.Email,
                    ResourceName = item.ResourceName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Manager = item.Manager,
                    SME = item.SME,
                    SMEStatus = item.SMEStatus,
                    ProgramStatus = item.ProgramStatus,
                    ProgramsTrackerId = item.ProgramsTrackerId,
                    ProgramsTracker = programtracker

                };
                resources.Add(newitem);
            }
            return resources;

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
