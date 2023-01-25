using ProgramAssignWebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.DTO
{
    public class ResourceManagerAssignmentDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int VAMID { get; set; }
        public string TechTrack { get; set; }
        public string ResourceName { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime EndDate { get; set; }
        public string Manager { get; set; }
        public string SME { get; set; }
        public string SMEStatus { get; set; }
        public string ProgramStatus { get; set; }
        // FK Key For 
        public int ProgramsTrackerId { get; set; }
        // Navigation prop
        // Binding navigation prop back to the region
        public ProgramsTracker ProgramsTracker { get; set; }
        // navigation prop for WalkDifficulty

    }
}
