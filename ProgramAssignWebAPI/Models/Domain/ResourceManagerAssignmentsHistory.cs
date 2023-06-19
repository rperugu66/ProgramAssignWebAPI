using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class ResourceManagerAssignmentsHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HistoryId { get; set; }
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
        // FK Key For 
        public int ProgramsTrackerId { get; set; }
        // Navigation prop
        // Binding navigation prop back to the region
        public ProgramsTracker ProgramsTracker { get; set; }
        public string HistoryProgramTrackerId { get; set; }
        public string ActionType { get; set; }
        // navigation prop for WalkDifficulty
        public string? SMEComments { get; set; }
        public string? ProgramCode { get; set; }
        public int? FileDetailsId { get; set; }
    //public FileDetails FileDetails { get; set; }
    //Swapna Added
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? AssociateSubmittedDate { get; set; }
        public int? AssociateDelayDays { get; set; }
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? SMEStartDate  { get; set; }
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? SMEEndDate { get; set; }
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? SMEApprovedDate { get; set; }
        public int? SMEDelayDays { get; set; }
    }
}
