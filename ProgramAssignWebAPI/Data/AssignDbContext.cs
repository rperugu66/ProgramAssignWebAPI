using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace ProgramAssignWebAPI.Data
{
    public class AssignDbContext : DbContext
    {

        //public AssignDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(Configuration.GetConnectionString("AssignPath"));
        //}
        //protected readonly IConfiguration Configuration;
        public AssignDbContext(DbContextOptions<AssignDbContext> options) : base(options)
        {
        }

        // Create Dbset Props to Create Resp Table in the SQL Server
        public DbSet<ResourceMangerAssignments> ResourceMangerAssignments { get; set; }
        public DbSet<ProgramsTracker> ProgramsTracker { get; set; }
        public DbSet<TechTracks> TechTracks { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<ResourceManagerAssignmentsHistory> ResourceManagerAssignmentsHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ResourceMangerAssignments>().ToTable("ResourceMangerAssignments", e => e.IsTemporal());
            modelBuilder.Entity<ResourceMangerAssignments>()
            .ToTable(tb => tb.HasTrigger("ResourceManagerAssignments_Update_Trigger"));
        }
        //{
        //modelBuilder.Entity<ResourceMangerAssignments>(entity =>
        //{
        //    entity.ToTable("ResourceMangerAssignments", e => e.IsTemporal());
        //    entity.HasOne(d => d.ProgramsTracker)
        //    .WithMany(p => p.)
        //    .HasForeignKey(d => d)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Employees_Statuses");
        //});
        //}


    }


}
