using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Data
{
    public class AssignDbContext : DbContext
    {
        public AssignDbContext(DbContextOptions<AssignDbContext> options) : base(options)
        {
        }
            // Create Dbset Props to Create Resp Table in the SQL Server
        public DbSet<ResourceMangerAssignments> ResourceMangerAssignments { get; set; }
        public DbSet<ProgramsTracker> ProgramsTracker { get; set; }
        public DbSet<TechTracks> TechTracks { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceMangerAssignments>().ToTable("ResourceMangerAssignments", e => e.IsTemporal());
        }
        //{
        //    modelBuilder.Entity<ResourceMangerAssignments>(entity =>
        //    {
        //        entity.ToTable("ResourceMangerAssignments", e => e.IsTemporal());
        //        entity.HasOne(d => d.ProgramsTracker)
        //        .WithMany(p => p.)
        //        .HasForeignKey(d => d)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Employees_Statuses");
        //    });
        //}

    }
    
    
}
