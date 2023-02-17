using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Controllers
{
    public class LoginInfoDbContext : DbContext
    {
        public LoginInfoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
