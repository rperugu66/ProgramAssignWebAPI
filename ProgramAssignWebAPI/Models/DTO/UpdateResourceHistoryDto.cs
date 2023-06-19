using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProgramAssignWebAPI.Models.Domain;

namespace ProgramAssignWebAPI.Models.DTO
{
    public class UpdateResourceHistoryDto
    {
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
        // FK Key For 
        
        // Navigation prop
        // Binding navigation prop back to the region
        
        
        // navigation prop for WalkDifficulty
        public string? SMEComments { get; set; }
        public string? ProgramCode { get; set; }

        //public int ProgramsTrackerId { get; set; }
        public string category { get; set; }

  }
}
