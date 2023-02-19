using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class ProgramsTracker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string TechTrack { get; set; }
        public string Category { get; set; }
        public string Program { get; set; }
        
    }
}
