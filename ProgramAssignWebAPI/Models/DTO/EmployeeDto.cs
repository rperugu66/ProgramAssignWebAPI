using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.DTO
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }
        public int VAMID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
