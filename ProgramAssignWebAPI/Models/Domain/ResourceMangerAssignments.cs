using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class ResourceMangerAssignments
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }
            public int VAMID { get; set; }
            public string TechTrack { get; set; }
        public string Email { get; set; }
        public string ResourceName { get; set; }
          [DataType(DataType.Date)]
          [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
            public string Manager { get; set; }
            public string SME { get; set; }
            public string SMEStatus { get; set; }
            public string ProgramStatus { get; set; }
            public string? SMEComments { get; set; }
            public string? ProgramCode { get; set; }
            // FK Key For 
            public int ProgramsTrackerId { get; set; }
            // Navigation prop
            // Binding navigation prop back to the region
            public ProgramsTracker ProgramsTracker { get; set; }
           public string HistoryProgramTrackerId { get; set;}
            // navigation prop for WalkDifficulty

    }
}
