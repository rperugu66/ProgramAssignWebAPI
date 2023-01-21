using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Data
{
    public class AssignDbContext :DbContext
    {
        public AssignDbContext(DbContextOptions<AssignDbContext> options) : base(options)
        {
            // Create Dbset Props to Create Resp Table in the SQL Server
                public DbSet<ResourceMangerAssignments> ResourceMangerAssignments { get; set; }
                public DbSet<ProgramsTracker> ProgramsTracker { get; set; }
    }
    }
}
