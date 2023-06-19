using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Data;
using ProgramAssignWebAPI.Models.Domain;
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

        public async Task<ResourceMangerAssignments> AddResource(ResourceMangerAssignments resource,string category)
        {
              
              Random random = new Random();
            


              var getPresentAssignedProgram = _dbContext.ResourceManagerAssignmentsHistory.Where(x => x.VAMID == resource.VAMID || x.EndDate > DateTime.Now.Date).Select(x => x.ProgramsTrackerId).ToArray();
              var getHistroyAssignedPrograms = _dbContext.ResourceManagerAssignmentsHistory.Where(x => x.VAMID == resource.VAMID).Select(x => int.Parse(x.HistoryProgramTrackerId)).ToArray();
              var totalExcludedPrograms = getPresentAssignedProgram.Concat(getHistroyAssignedPrograms).ToArray();

              var getAllPrograms = _dbContext.ProgramsTracker.Where(x => x.TechTrack == resource.TechTrack && (category == "All Categories" || x.Category == category)).Select(x => x.Id).ToArray();

              var resultPrograms = getAllPrograms.Except(totalExcludedPrograms).ToArray();

              resource.ProgramsTrackerId = resultPrograms[random.Next(resultPrograms.Length)];

              resource.HistoryProgramTrackerId = resource.ProgramsTrackerId.ToString();

              var dbResource = await _dbContext.ResourceMangerAssignments.AddAsync(resource);
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
        public async Task<IEnumerable<ResourceManagerAssignmentsHistory>> GetAllHistoryResourceAsync()
        {
            return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker).ToListAsync();
        }
        public async Task<ResourceMangerAssignments> GetResourceByEmailId(string email)
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ResourceMangerAssignments> GetResourceById(int Id)
        {
            return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<ResourceManagerAssignmentsHistory>> GetResourceHistoryById(int Id)
        {
           var response = await  _dbContext.ResourceManagerAssignmentsHistory.Include(x =>x.ProgramsTracker).Where(x => x.Id == Id).ToListAsync();
           //IList<ResourceMangerAssignments> resources = new List<ResourceMangerAssignments>();
           // var GetAllPrograms =await _dbContext.ProgramsTracker.ToListAsync();
           // foreach (var item in response)
           // {
           //     // make call to service and get programtackerby id
           //     var programtracker = GetAllPrograms.FirstOrDefault(x => x.Id == item.ProgramsTrackerId);
           //         //await _dbContext.ProgramsTracker.FirstOrDefaultAsync(x => x.Id == item.ProgramsTrackerId);
           //     var newitem = new ResourceMangerAssignments()
           //     {
           //         Id = item.Id,
           //         VAMID = item.VAMID,
           //         Email = item.Email,
           //         ResourceName = item.ResourceName,
           //         StartDate = item.StartDate,
           //         EndDate = item.EndDate,
           //         Manager = item.Manager,
           //         SME = item.SME,
           //         SMEStatus = item.SMEStatus,
           //         ProgramStatus = item.ProgramStatus,
           //         ProgramsTrackerId = item.ProgramsTrackerId,
           //         ProgramsTracker = programtracker

           //     };
           //     resources.Add(newitem);
           // }
            return response.ToList();

        }

        public async Task<ResourceManagerAssignmentsHistory> GetResourceHistorySingleById(int Id)
        {
            return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker).Where(x => x.HistoryId == Id).FirstOrDefaultAsync();
        }

        

        //public async Task<ResourceManagerAssignmentsHistory> GetSmeByName(string SME)
        //{
        //    return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker).FirstOrDefaultAsync(x => x.SME == SME);
        //}

        public async Task<ResourceMangerAssignments> UpdateResource(int id, ResourceMangerAssignments resource)
        {
            var resourcefromdb = await _dbContext.ResourceManagerAssignmentsHistory.FindAsync(id);
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
                //resourcefromdb.SMEComments = resource.SMEComments;
                //resourcefromdb.ProgramCode = resource.ProgramCode;
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch(Exception ex) { var msg = ex; }
               
                return await _dbContext.ResourceMangerAssignments.Include(x => x.ProgramsTracker)
                    .FirstOrDefaultAsync(x => x.Id == resourcefromdb.Id);
            }
            return null;
        }

        public async Task<ResourceManagerAssignmentsHistory> UpdateResourceHistory(int id, ResourceManagerAssignmentsHistory resourcehistory, string category)
        {
            var resourcefromdb = await _dbContext.ResourceManagerAssignmentsHistory.FindAsync(id);
            if (resourcefromdb != null)
            {
                resourcefromdb.VAMID = resourcehistory.VAMID;
                resourcefromdb.ResourceName = resourcehistory.ResourceName;
                resourcefromdb.Email = resourcehistory.Email;
                resourcefromdb.TechTrack = resourcehistory.TechTrack;
                resourcefromdb.StartDate = resourcehistory.StartDate;
                resourcefromdb.EndDate = resourcehistory.EndDate;
                resourcefromdb.SME = resourcehistory.SME;
                resourcefromdb.Manager = resourcehistory.Manager;
                resourcefromdb.SMEComments = resourcehistory.SMEComments;
                resourcefromdb.ProgramCode = resourcehistory.ProgramCode;
                Random random = new Random();


              var getPresentAssignedProgram = _dbContext.ResourceManagerAssignmentsHistory.Where(x => x.VAMID == resourcehistory.VAMID || x.EndDate > DateTime.Now.Date).Select(x => x.ProgramsTrackerId).ToArray();
              var getHistroyAssignedPrograms = _dbContext.ResourceManagerAssignmentsHistory.Where(x => x.VAMID == resourcehistory.VAMID).Select(x => int.Parse(x.HistoryProgramTrackerId)).ToArray();
              var totalExcludedPrograms = getPresentAssignedProgram.Concat(getHistroyAssignedPrograms).ToArray();

              var getAllPrograms = _dbContext.ProgramsTracker.Where(x => x.TechTrack == resourcehistory.TechTrack && ( x.Category == category)).Select(x => x.Id).ToArray();

              var resultPrograms = getAllPrograms.Except(totalExcludedPrograms).ToArray();

              resourcehistory.ProgramsTrackerId = resultPrograms[random.Next(resultPrograms.Length)];

              resourcehistory.HistoryProgramTrackerId = resourcehistory.ProgramsTrackerId.ToString();
              
              if (resourcefromdb.HistoryProgramTrackerId != resourcefromdb.ProgramsTrackerId.ToString())
              {
                  resourcefromdb.HistoryProgramTrackerId = resourcefromdb.HistoryProgramTrackerId + "," + resourcefromdb.ProgramsTrackerId;
              }

                resourcefromdb.ProgramsTrackerId = resourcehistory.ProgramsTrackerId;

                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex) { var msg = ex; }

                return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker)
                    .FirstOrDefaultAsync(x => x.Id == resourcefromdb.Id);
            }
            return null;
        }

        public async Task<ResourceManagerAssignmentsHistory> UpdateResourceHistoryCode(int id, ResourceManagerAssignmentsHistory resourcehistory)
        {

            var resourcefromdb = await _dbContext.ResourceManagerAssignmentsHistory.FindAsync(id);
            if (resourcefromdb != null)
            {

                if(resourcefromdb.ProgramStatus == "Open" && resourcehistory.ProgramStatus == "Submitted")
                {
                    resourcefromdb.AssociateSubmittedDate = DateTime.Today.Date;

                    if (resourcefromdb.AssociateSubmittedDate > resourcefromdb.EndDate)
                      resourcefromdb.AssociateDelayDays = (DateTime.Today.Date - resourcefromdb.EndDate).Days;
                    else
                      resourcefromdb.AssociateDelayDays = 0;

                    resourcefromdb.SMEStartDate = DateTime.Today.Date;
                    resourcefromdb.SMEEndDate = DateTime.Today.AddDays(4).Date;
                }

        
                resourcefromdb.ProgramStatus = resourcehistory.ProgramStatus;
                resourcefromdb.ProgramCode = resourcehistory.ProgramCode;
                resourcefromdb.SMEComments = resourcehistory.SMEComments;


                if (resourcehistory.ProgramStatus == "Approved")
                {
                  resourcefromdb.SMEApprovedDate = DateTime.Today.Date;

                  if (resourcefromdb.SMEApprovedDate > resourcefromdb.SMEEndDate)
                    resourcefromdb.SMEDelayDays = DateTime.Today.Date.Day;
                  else
                    resourcefromdb.SMEDelayDays = 0;
                }

                 
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex) { var msg = ex; }

                return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker)
                    .FirstOrDefaultAsync(x => x.Id == resourcefromdb.Id);
            }
            return null;
        }

        //async Task<IEnumerable<ResourceManagerAssignmentsHistory>> IResourceManagerAssignmentRepo.GetAllHistoryResourceAsync()
        //{
        //    return await _dbContext.ResourceManagerAssignmentsHistory.Include(x => x.ProgramsTracker).ToListAsync();
        //}
    }
}
