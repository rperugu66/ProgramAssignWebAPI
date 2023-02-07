using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class VAM_Holidays
    {
        [Key]
        public DateTime Holidays { get; set; }
    }
}
