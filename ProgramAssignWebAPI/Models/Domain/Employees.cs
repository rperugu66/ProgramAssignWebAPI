using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class Employees
    {

        [Key]
        public int Id { get; set; }
        public int VAMID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public  string Role { get; set; }
    }
}
