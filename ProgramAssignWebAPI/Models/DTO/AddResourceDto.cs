namespace ProgramAssignWebAPI.Models.DTO
{
    public class AddResourceDto
    {
        public int VAMID { get; set; }
        public string TechTrack { get; set; }
        public string ResourceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Manager { get; set; }
        public string SME { get; set; }
        public string SMEStatus { get; set; }
        public string ProgramStatus { get; set; }
        // FK Key For 
        //public int ProgramsTrackerId { get; set; }
    }
}
