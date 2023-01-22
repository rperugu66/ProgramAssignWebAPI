using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgramAssignWebAPI.Models.Domain
{
    public class TechTracks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string TechTrack { get; set; }
    }
}
